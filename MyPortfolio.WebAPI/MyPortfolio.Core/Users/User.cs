using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Core.Users;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string Salt { get; set; }

    public Role Role { get; set; }
}
