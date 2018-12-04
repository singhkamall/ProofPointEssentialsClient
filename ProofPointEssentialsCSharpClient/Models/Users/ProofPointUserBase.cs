using ProofPointEssentialsCSharpClient.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Models.Users
{
    public abstract class ProofPointUserBase
    {
        public enum ProofPointUserTypes
        {
            oem_partner_admin,
            strategic_partner_admin,
            channel_admin,
            organization_admin,
            end_user,
            silent_user,
            functional_account
        }

        /// <summary>
        /// This field is required.
        /// example: john.smith@mydomain.com
        /// </summary>
        public string primary_email { get; set; }

        public bool is_active { get; set; }

        //public ProofPointUserTypes user_Type { get; set; }

        /// <summary>
        /// Must be const value.
        /// Use ProofPointEssentialsCSharpClient.Models.Enums.ProofPointUserTypes to get valid values and convert it into string
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// POST only: should the user receive a welcome email on creation
        /// </summary>
        public bool send_welcome_email { get; set; }

        public string firstname { get; set; }

        public string surname { get; set; }

        /// <summary>
        /// example: List [ "john@mydomain.com", "jsmith@mydomain.com" ]
        /// </summary>
        public List<string> alias_emails { get; set; }

        /// <summary>
        /// example: List [ "jane@gooddomain.com", "bill@anothergooddomain.com" ]
        /// </summary>
        public List<string> white_list_senders { get; set; }

        /// <summary>
        /// example: List [ "bob@baddomain.com", "orders@anotherbaddomain.com" ]
        /// </summary>
        public List<string> black_list_senders { get; set; }

        /// <summary>
        /// is the user a billable user? (NOTE: Only one user per org can be non-billable)
        /// </summary>
        public bool is_billable { get; set; }

        public User_Odin_Settings odin_settings { get; set; }
    }
}