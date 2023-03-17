
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using Shop.Structure;
using Shop.DataBase;

namespace Shop.Data
{
    public class LoginController
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //public Employee employee { get; set; }
        public bool CheckLoginPassword()
        {

            SHA1 sha1 = SHA1.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(this.Password);
            byte[] hashedBytes = sha1.ComputeHash(passwordBytes);
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            LoginController loginFromDB;
            using (StoreDBContext dbcontext = new StoreDBContext())
            {

                loginFromDB = dbcontext.Logins.Where(x => x.Login == this.Login && x.Password==hashedPassword).FirstOrDefault();
                
            }

            if(loginFromDB == null){
                return false;
            }else{
                return true;
            }

        }

        public async Task SaveLoginPassword()
        {

            SHA1 sha1 = SHA1.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(this.Password);
            byte[] hashedBytes = sha1.ComputeHash(passwordBytes);
            this.Password = Convert.ToBase64String(hashedBytes);

            using (StoreDBContext dbcontext = new StoreDBContext())
            {
                await dbcontext.AddAsync(this);
                await dbcontext.SaveChangesAsync();
            }

        }

    }
}