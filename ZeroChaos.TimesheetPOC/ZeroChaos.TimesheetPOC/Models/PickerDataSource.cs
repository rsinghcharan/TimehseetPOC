#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Models
{
    public static class PickerDataSource
    {
        public class DashboardItems
        {
            public List<Student> dashboardItems { get; set; }
        }
        public class Student
        {
            public string Title { get; set; }
            public string ImageName { get; set; }
            public string StyleID { get; set; }
            public int BubbleCount { get; set; }
        }
        public static DashboardItems getManagerData()
        {
            var gq = new DashboardItems
            {
                dashboardItems = new List<Student>
    {
     new Student {Title = "Approve Timesheet", ImageName = "timesheet.png", StyleID="approve-timesheet", BubbleCount=2},
     new Student {Title = "Approve Expense", ImageName = "expense.png", StyleID="approve-expense", BubbleCount=3},
     new Student {Title = "Approve Projects", ImageName = "project.png", StyleID="approve-project", BubbleCount=4},
     new Student {Title = "Approve Timesheet", ImageName = "timesheet.png", StyleID="approve-timesheet", BubbleCount=2},
     new Student {Title = "Approve Adjustment", ImageName = "adjustment.png", StyleID="approve-adjustment", BubbleCount=10},
     new Student {Title = "Approve Service Invoice", ImageName = "invoice.png", StyleID="approve-service-invoice", BubbleCount=11},
     new Student {Title = "Manage Submissions", ImageName = "sowrequisitionIcon.png", StyleID="approve-sow-requisition"},
     new Student {Title = "Approve SOW Engagement", ImageName = "sowengagements.png", StyleID="approve-sow-engagement", BubbleCount=15},
     new Student {Title = "Approve Requisition", ImageName = "sowRequisitionicon.png", StyleID="approve-sow-requisition", BubbleCount=10},
     new Student {Title = "Create Expense Report", ImageName = "expense.png", StyleID="create-expense-report"},
     new Student {Title = "View Timesheets", ImageName = "timesheet.png", StyleID="view-timesheet"},
     new Student {Title = "Welcome Mobile", ImageName = "dossier.png", StyleID="welcome-mobile"},
     new Student {Title = "Create Timesheet", ImageName = "timesheet.png", StyleID="create-timesheet"},
     new Student {Title = "View Projects", ImageName = "project.png", StyleID="view-project"},
     new Student {Title = "View Expenses", ImageName = "expense.png", StyleID="view-expenses"},
     new Student {StyleID="contact-us", ImageName="loginlogo.png"},
     new Student {Title = "Manage Engagement", ImageName = "sowengagements.png", StyleID="manage-engagement"}

    }
            };

            return gq;
        }
        public static DashboardItems getSupplierData()
        {
            var gq = new DashboardItems
            {
                dashboardItems = new List<Student>
    {


     new Student {Title = "Create Timesheet", ImageName = "timesheet.png", StyleID="create-timesheet"},
     new Student {Title = "Create Expense Report", ImageName = "expense.png", StyleID="create-expense-report"},
     new Student {Title = "Manage Submissions", ImageName = "sowrequisitionicon.png", StyleID="approve-sow-requisition"},
     new Student {Title = "View Pay History", ImageName = "payment.png", StyleID="view-pay-history"},
     new Student {Title = "Welcome Mobile", ImageName = "dossier.png", StyleID="welcome-mobile"},
     new Student {Title = "View Projects", ImageName = "project.png", StyleID="view-project"},
     new Student {Title = "View Expenses", ImageName = "expense.png", StyleID="view-expenses"},
	 new Student {Title = "View Timesheets", ImageName = "timesheet.png", StyleID="view-timesheet"},
     new Student {Title = "View Invoices", ImageName = "invoice.png", StyleID="view-invoices"},
     new Student {StyleID="contact-us", ImageName="loginlogo.png"}
    }
            };

            return gq;
        }

        public static DashboardItems getResourceData()
        {
            var gq = new DashboardItems
            {
                dashboardItems = new List<Student>
    {
     new Student {Title = "Create Timesheet", ImageName = "timesheet.png", StyleID="create-timesheet"},
     new Student {Title = "View Pay History", ImageName = "payment.png", StyleID="view-pay-history"},
     new Student {Title = "Create Expense Report", ImageName = "expense.png", StyleID="create-expense-report"},
     new Student {Title = "View Timesheets", ImageName = "timesheet.png", StyleID="view-timesheet"},
     new Student {Title = "Welcome Mobile", ImageName = "dossier.png", StyleID="welcome-mobile"},
     new Student {Title = "View Expenses", ImageName = "expense.png", StyleID="view-expenses"},
     new Student {StyleID="contact-us", ImageName="loginlogo.png"}
    }
            };

            return gq;
        }
        public static string[] getLeftTileColors()
        {
            string[] leftTileColorCollection = new string[] { "#007DCC", "#006282", "#004E7F", "#002740", "#007DCC", "#006282", "#004E7F", "#002740", "#007DCC", "#006282", "#004E7F", "#002740", "#007DCC", "#006282", "#004E7F", "#002740", "#007DCC", "#006282", "#004E7F", "#002740", "#007DCC", "#006282", "#004E7F", "#002740" };
            return leftTileColorCollection;
        }
        public static string[] getRightTileColors()
        {
            string[] rightTileColorCollection = new string[] { "#CF6900", "#B55C00", "#8F4900", "#CF6900", "#B55C00", "#8F4900", "#CF6900", "#B55C00", "#8F4900", "#CF6900", "#B55C00", "#8F4900", "#CF6900", "#B55C00", "#8F4900", "#002740" };
            return rightTileColorCollection;
        }
    }
}
