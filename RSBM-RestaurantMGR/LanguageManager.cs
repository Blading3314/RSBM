using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public static class LanguageManager
    {
        private static ResourceManager _resourceManager;
        private static CultureInfo _currentCulture;
        private static readonly Dictionary<string, string> ResourceKeys = new Dictionary<string, string>
        {
            { "RestoForm", "MainForm_Title" },
            { "label1", "MainForm_Header" },
            { "btnReservations", "MainForm_Reservations" },
            { "btnTables", "MainForm_Tables" },
            { "btnBilling", "MainForm_Billing" },
            { "lblLanguage", "MainForm_Language" },
            { "quitButton", "MainForm_Quit" },

            { "reservations", "ReservationForm_Header" },
            { "lblCustomerInfo", "ReservationForm_CustomerInfo" },
            { "lblReservationDetails", "ReservationForm_ReservationDetails" },
            { "lblName", "ReservationForm_CustomerName" },
            { "lblPhone", "ReservationForm_Phone" },
            { "lblPartySize", "ReservationForm_PartySize" },
            { "lblDate", "ReservationForm_Date" },
            { "lblTime", "ReservationForm_Time" },
            { "lblTable", "ReservationForm_Table" },
            { "lblStatus", "ReservationForm_Status" },
            { "lblSearch", "ReservationForm_Search" },
            { "todayCheckBox", "ReservationForm_ShowToday" },
            { "btnAddReservation", "ReservationForm_AddReservation" },
            { "btnEditReservation", "ReservationForm_EditReservation" },
            { "btnDeleteReservation", "ReservationForm_DeleteReservation" },
            { "btnClear", "ReservationForm_Clear" },
            { "btnRefresh", "ReservationForm_Refresh" },

            { "tables", "TableForm_Header" },
            { "tableID", "TableForm_SelectedTable" },
            { "editTableLabel", "TableForm_EditTable" },
            { "statusLabel", "TableForm_Status" },
            { "typeLabel", "TableForm_Type" },
            { "tableStatusDateLabel", "TableForm_StatusDate" },
            { "btnUpdateTable", "TableForm_UpdateTable" },

            { "billing", "BillingForm_Header" },
            { "tableInfoGroupBox", "BillingForm_TableInfo" },
            { "tableInfoLabel", "BillingForm_Info" },
            { "tableIdLabel", "BillingForm_Table" },
            { "aycePricingGrpupBox", "BillingForm_Pricing" },
            { "numGuestsLabel", "BillingForm_NumberOfPeople" },
            { "priceLabel", "BillingForm_PricePerPerson" },
            { "paymentMethodGroupBox", "BillingForm_PaymentMethod" },
            { "paymentMethodLabel", "BillingForm_Payment" },
            { "totalLabel", "BillingForm_Total" },
            { "tipLabel", "BillingForm_Tip" },
            { "subtotalLabel", "BillingForm_Subtotal" },
            { "extrasGroupBox", "BillingForm_Extras" },
            { "premiumCheckBox", "BillingForm_PremiumMeat" },
            { "drinksCheckBox", "BillingForm_Drinks" },
            { "btnGenerateBill", "BillingForm_GenerateBill" },
            { "lblPrice", "BillingForm_PricingSection" },
            { "label2", "BillingForm_ExtrasSection" },
            { "label3", "BillingForm_PaymentSection" },
            { "reservationLabel", "BillingForm_Reservation" },
            { "BillIDLabel", "BillingForm_BillID" },
            { "btnUpdateStatus", "BillingForm_UpdateStatus" },
            { "DeleteButton", "BillingForm_DeleteBill" }
        };

        static LanguageManager()
        {
            _resourceManager = new ResourceManager("RSBM_RestaurantMGR.Resources.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            _currentCulture = CultureInfo.CurrentCulture;
        }

        public static string GetString(string key)
        {
            try
            {
                return _resourceManager.GetString(key, _currentCulture) ?? key;
            }
            catch
            {
                return key;
            }
        }

        public static void SetCulture(string cultureCode)
        {
            try
            {
                _currentCulture = new CultureInfo(cultureCode);
                Thread.CurrentThread.CurrentUICulture = _currentCulture;
                Thread.CurrentThread.CurrentCulture = _currentCulture;
            }
            catch
            {
                _currentCulture = CultureInfo.CurrentCulture;
            }
        }

        public static string GetCurrentCulture()
        {
            return _currentCulture.TwoLetterISOLanguageName;
        }

        public static void ApplyLanguageToForm(Form form)
        {
            if (form == null) return;

            // Update form title
            var titleKey = GetResourceKey(form) ?? string.Format("{0}_Title", form.Name);
            var title = GetString(titleKey);
            if (title != titleKey)
            {
                form.Text = title;
            }

            // Update all controls recursively
            ApplyLanguageToControls(form.Controls);
        }

        private static void ApplyLanguageToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Label || control is Button || control is CheckBox || control is GroupBox)
                {
                    var key = GetResourceKey(control);
                    if (string.IsNullOrEmpty(key))
                    {
                        key = control.Name;
                    }

                    var text = GetString(key);
                    if (text != key)
                    {
                        control.Text = text;
                    }
                }

                // Recursively apply to child controls
                if (control.HasChildren)
                {
                    ApplyLanguageToControls(control.Controls);
                }
            }
        }

        private static string GetResourceKey(Control control)
        {
            if (control == null)
            {
                return null;
            }

            var tagKey = control.Tag as string;
            if (!string.IsNullOrWhiteSpace(tagKey))
            {
                return tagKey;
            }

            string resourceKey;
            return ResourceKeys.TryGetValue(control.Name, out resourceKey) ? resourceKey : null;
        }

        public static void UpdateComboBoxItems(ComboBox comboBox, params string[] resourceKeys)
        {
            if (comboBox == null) return;

            comboBox.Items.Clear();
            foreach (var key in resourceKeys)
            {
                comboBox.Items.Add(GetString(key));
            }
        }
    }
}
