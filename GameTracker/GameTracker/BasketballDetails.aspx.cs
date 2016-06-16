using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements required for EF DB access
using GameTracker.Models;
using System.Web.ModelBinding;

namespace GameTracker
{
    public partial class BasketballDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetBasketball();
            }
        }

        protected void GetBasketball()
        {
            // populate teh form with existing data from the database
            int basketballID = Convert.ToInt32(Request.QueryString["basketballID"]);

            // connect to the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                Basketball updatedBasketball = (from basketball in db.Basketball
                                          where basketball.basketballtID == basketballID
                                                select basketball).FirstOrDefault();

                if(updatedBasketball != null)
                {
                    teamName1TextBox.Text = updatedBasketball.teamName1;
                    teamName2TextBox.Text = updatedBasketball.teamName2;
                    

                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Basketball.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                // save a new record
                Basketball newBasketball = new Basketball();

                int basketballID = 0;

                if(Request.QueryString.Count > 0) 
                {
                    // get the id from the URL
                    basketballID = Convert.ToInt32(Request.QueryString["basketballtID"]);

                    newBasketball = (from basktball in db.Basketball
                                  where basketball.basketballID == basketballID
                                  select Basketball).FirstOrDefault();
                }

                newBasketball.teamName1 = teamName1TextBox.Text;
                newBasketball.teamName2 = teamName2TextBox.Text;


                if (basketballID == 0) {
                    db.Basketball.Add(newBasketball);
                }
                

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated  page
                Response.Redirect("~/BasketballF.aspx");
            }
        }
    }
}