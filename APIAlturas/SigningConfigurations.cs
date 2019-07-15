using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace APIAlturas
{
    public class SigningConfigurations
    {
        // Armazena a chave de criptografia usada na criação dos tokens
        public SecurityKey Key { get; }

        // Conterá a chave de criptografia e o algoritmo de segurança empregado na geração 
        // de assinaturas digitais para tokens
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            // Especifica que será usado o algoritmo RSA para criptografia
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
