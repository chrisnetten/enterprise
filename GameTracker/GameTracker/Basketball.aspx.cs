using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to EF DB
using GameTracker.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace GameTracker
{
    public partial class Basketball : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "basketballID"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the data
                this.GetBasketball();
            }
        }

        /**
         * <summary>
         * This method gets the data from the DB
         * </summary>
         * 
         * @method G
         * @returns {void}
         */
        protected void GetBasketball()
        {
            // connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Table using EF and LINQ
                var Basketball = (from allBasketball in db.Basketball
                                select allBasketball);

                // bind the result to the GridView
                BasketballView.DataSource = Basketball.AsQueryable().OrderBy(SortString).ToList();
                BasketballView.DataBind();
            }
        }

        /**
         * <summary>
         * This event handler deletes from the db using EF
         * </summary>
         * 
         * @method GridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
        protected void BasketballGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected StudentID using the Grid's DataKey collection
            int basketballID = Convert.ToInt32(BasketballGridView.DataKeys[selectedRow].Values["basketballID"]);

            // use EF to find the selected student in the DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {
                // create object of the Student class and store the query string inside of it
                Basketball deletedBasketball = (from basketballRecords in db.Basketball
                                             where basketballRecords.basketballID == basketballID
                                             select basketballRecords).FirstOrDefault();

                // remove the selected rom the db
                db.Students.Remove(deletedBasketball);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetBasketball();
            }
        }
    }
}

