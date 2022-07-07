using PlantillaApiSAADS.DTOs;
using System.Security.Claims;

namespace PlantillaApiSAADS.Helpers
{
    public class UserJWT
    {
        private readonly IHttpContextAccessor _httpAccessor;
        public UserJWT(IHttpContextAccessor httpContextAccessor)
        {
            _httpAccessor = httpContextAccessor;
        }

        public UserAuth? userAuth
        {
            get
            {
                if (_httpAccessor.HttpContext != null)
                {
                    if (_httpAccessor.HttpContext.User != null)
                    {
                        if (_httpAccessor.HttpContext.User.Identity != null)
                        {
                            if (_httpAccessor.HttpContext.User.Identity.IsAuthenticated)
                            {
                                var user = _httpAccessor.HttpContext.User;
                                var token = _httpAccessor.HttpContext.Request.Headers["Authorization"].ToString();

                                
                                                                
                                var xuserAuth = new UserAuth
                                {
                                    Id = int.Parse(user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)!.Value),                                   
                                    Email = user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)!.Value,
                                    UserName = user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)!.Value,
                                                                  
                                    Tipo = user.Claims.FirstOrDefault(a => a.Type == "tipo")!.Value,
                                    SedeId = int.Parse(user.Claims.FirstOrDefault(a => a.Type == "sedeId")!.Value),
                                    SedeNombre = user.Claims.FirstOrDefault(a => a.Type == "sede")!.Value,
                                    Expiracion = long.Parse(user.Claims.FirstOrDefault(a => a.Type == "exp")!.Value),
                                    Token = token,
                                   
                                };

                                if (xuserAuth.Tipo.ToUpper() == "FUNCIONARIO")
                                {
                                    xuserAuth.AplicacionId = int.Parse(user.Claims.FirstOrDefault(a => a.Type == "aplicacionId")!.Value);    
                                    xuserAuth.CargoId = int.Parse(user.Claims.FirstOrDefault(a => a.Type == "cargoId")!.Value);
                                    xuserAuth.CargoNombre = user.Claims.FirstOrDefault(a => a.Type == "cargo")!.Value;
                                    
                                }

                                return xuserAuth;
                            }
                        }

                    }
                }


                return null;
            }
        }
    }
}
