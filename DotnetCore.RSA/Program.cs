using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSATest
{
    class Program
    {
        static void Main(string[] args)
        {
			//2048 public key
	        string publicKey =
"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwQrp0Oj4LdhK53npjgwmHM7VWwv1xVSKsJnVsQzGeMBcTdRV5BKjOd9UCRT7ttWLg6b3qBUkY5Gkxuj8W+bEqlhMinkO+jq5bC3xqA6889jfB/ksI1jAC8tF85PK80lcgoB+yHcu1QybZeVZuEv2wNoxQjAgr2+6GnMZMSDXREOxA0IObdK3d+RtdWfEu3izwpfuL3ai3Tu5zIrEWGKiGe3FNA0nSaUU1Ln22/kH72dVcsrbjcvybqYsZxcPDXICukx2uFoqWvJFCSvZonQYnsjnGu1wWjvVl9orsNkB4D+b7KZlisGNOqftm25nNms+trGjvzIfy2gni9AFxwZkvwIDAQAB";
			//2048 private key
	        string privateKey =
"MIIEpAIBAAKCAQEAwQrp0Oj4LdhK53npjgwmHM7VWwv1xVSKsJnVsQzGeMBcTdRV5BKjOd9UCRT7ttWLg6b3qBUkY5Gkxuj8W+bEqlhMinkO+jq5bC3xqA6889jfB/ksI1jAC8tF85PK80lcgoB+yHcu1QybZeVZuEv2wNoxQjAgr2+6GnMZMSDXREOxA0IObdK3d+RtdWfEu3izwpfuL3ai3Tu5zIrEWGKiGe3FNA0nSaUU1Ln22/kH72dVcsrbjcvybqYsZxcPDXICukx2uFoqWvJFCSvZonQYnsjnGu1wWjvVl9orsNkB4D+b7KZlisGNOqftm25nNms+trGjvzIfy2gni9AFxwZkvwIDAQABAoIBAQCq+v6T4fUHrh7SHYIHJa2QMIZ7CQHbkQDyYJ8MHVOhWkenS93zj6pxNOSa0rIMg+H5bqbGgktjwXlgELaMs74XXvQUZhsk+WSIc70p7DviA4Gv7zvv5sja6WWA07ObfqvojuU8q4uYen0daGHqQaZBtECS7kvU97GvgaibggoI1B392hMCPVt+Pi76VxIaYeoKDBiiYRTdMKYDMXUqAA+zPA5cEFQqdKjPsmVlHnxjj9aRd/rUwtb33blJf8NKmLO7in/33ERRxph4sf2EC2t5CnosS1E9pKd3UjN4i6o3OX3VV4glaXZc1++r6f8czOqfhTkJ9E2yca2rmmaAHE3BAoGBAOSTA7jWetlp+vgEIeTicxYk0MA1E6mWIvCJTdRijzWLCZ4zJy0ElFlLfsbNts0AzPvoRoseex4fOxvucHBRvvChjHvtEsl3UzLcuTgUhTfTvU//LW8ZUAhEjK5N/CETKEf8A5hNBHtFmW92/hS8woSHKEkmFHm9kF+qQUqUxcThAoGBANg0fllq+Y03f1EpZR1MOKB4S4S5mOsg6A6I35JJAYsEq+7DjJX7e0um0YXar6ZgxO8sjyKztfu65YkTmou5O/VB1sK3bopZdDhfqD7D7p/a5DOfqXP9cxpJypPn58E5ddfRyy32QUodmlRnmVrPupLV9hS7CsiEQpG/shDBt72fAoGAAarI1ipKTxekyvZMwPyd1kWCeERq1kvQCW0W8judy8gt08ePu5ZS9qvESvLpKGmfFR9GlHEueLPFnJiKnWcbO2oSOj0qa+nA45gUicIsjpGuycyUqkDHAqhtVkAfXKZlHtFJvWyiYbvKOLPneoM97/WEZ7QtZg3p5ai6PS8EmkECgYEAqwaLVCx9D6pw+kDmjZB30uiVxH4UaxrytlyrjkpWACRH5W2mzhXK6IMjhuEAxXoTDqeO6oKCWIj1fcOWIyT6Ov5D5m+375TnjJiOvGe9YZKDphqMrwY0gP0SVIHEIGNVxs1cDhWYfAqCxHXXJ7DfA7xhFvEGjKujBSxArWSv9j0CgYBvpSeshLXE03bRVZZAzorfmK3C2gjLt8SIV9EY0UbocTACQPatHv27dvsRjUpxsIHvzWczecem2gj1/bE0Yodc/82OwIF/z6cMv2vg4QjcG8n3ll7mzJ+m8kC7ARqZPaezrhR438CWofT4l24lIGWCABF0G2CtJG0x1qiYJeOFpw==";
			var rsa = new RSAHelper(RSAType.RSA2,Encoding.UTF8, privateKey, publicKey);

	        string str = "http://www.cnblogs.com/";

			Console.WriteLine("Original string: "+str);

			//Encrypted
	        string enStr = rsa.Encrypt(str);

			Console.WriteLine("encrypted: "+enStr);

			//Decrypted
	        string deStr = rsa.Decrypt(enStr);

			Console.WriteLine("Decrypted："+deStr);

			//Private key signature
	        string signStr = rsa.Sign(str);

	        Console.WriteLine("String signature：" + signStr);

	        //Public key verification signature
	        bool signVerify = rsa.Verify(str,signStr);

	        Console.WriteLine("Verification signature：" + signVerify);
        }

	}
}
