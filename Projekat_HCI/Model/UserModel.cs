using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekat_HCI.Model
{
    [Serializable]
    public class UserModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        
        public UserRole Role { get; set; }

        public UserModel() { }
        
        public UserModel(string username, string password, UserRole role)
        {
                Username = username;
                Password = password;
                Role = role;
        } 
        public UserModel(string username, string password)
        {
                Username = username;
                Password = password;              
                
        }
       
        public override string ToString()
        {
            return Username + " " + Password + " " + Role.ToString(); 
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            UserModel otherUser = (UserModel)obj;
            return Username == otherUser.Username &&
                   Password == otherUser.Password;
                   
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password, Role);
        }
    }

    public enum UserRole
    {
        Unknown,
        Guest,
        Admin
    }
}
