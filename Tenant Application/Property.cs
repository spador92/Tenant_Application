//Name: Sean Pador
//Project: Tenant Application
//Project Info: App for Rental Properties that is web based. This program uses a class called Property 
//and creates an array and collection from its objects. Both the array and collection will keep track 
//of the same objects. These properties can be filled by tenants and these
//tenants are given a fixed rent due that comes every month which they must pay. The user can also evict them.
//Language: C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenant_Application
{
    public class Property
    {
        //The information about the tenant
        private String firstName;
        private String lastName;
        private int familySize;
        private int currentDue;
        private int months;
        private int rentPay;
        private Boolean occupied;
        private int propertyNum;

        //Method: firstName
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for name parameter
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        //Method: lastName
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for name parameter
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        //Method: FamilySize
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for familySize parameter
        public int FamilySize
        {
            get
            {
                return familySize;
            }
            set
            {
                familySize = value;
            }
        }

        //Method: currentDue
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for familySize parameter
        public int CurrentDue
        {
            get
            {
                return currentDue;
            }
            set
            {
                currentDue = value;
            }
        }

        //Method: Months
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for months parameter
        public int Months
        {
            get
            {
                return months;
            }
            set
            {
                months = value;
            }
        }

        //Method: RentPay
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for rentPay parameter
        public int RentPay
        {
            get
            {
                return rentPay;
            }
            set
            {
                rentPay = value;
            }
        }

        //Method: Occupied
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for occupied parameter
        public Boolean Occupied
        {
            get
            {
                return occupied;
            }
            set
            {
                occupied = value;
            }
        }

        //Method: Occupied
        //Input: None 
        //Output: Modifies field or returns field
        //Purpose: Set and get method for propertNum parameter
        public int PropertyNum
        {
            get
            {
                return propertyNum;
            }
            set
            {
                propertyNum = value;
            }
        }

        //Method: payRent
        //Input: int pay
        //Output: Nothing is directly returned, The field(s) in the object is slightly modified
        //This method holds the value of the amount to be paid and automatically deducts rentPay from it
        public void payRent(int pay)
        {
            rentPay += pay;

            //When any rent pay is left pay anything left
            if (currentDue < 0)
            {
                currentDue += rentPay;
                //When amonut paid surpasses due return any access amount to rentPay
                if (currentDue > 0)
                {
                    rentPay = currentDue;
                    currentDue = 0;
                }
                else
                {
                    rentPay = 0;
                }
            }
        }

        //Method: nextMonth
        //Input: None
        //Output: Does not directly return anything. It modifies element(s) of array.
        //Purpose: This method advances the month of all current tenants.
        public void nextMonth(int due)
        {
            currentDue -= due;   //Add to debt                
            currentDue += rentPay;  //Will deduct any rentPay left from the due.

            if (currentDue > 0)  //When amonut paid surpasses due return any access money to rentPay
            {
                rentPay = currentDue;
                currentDue = 0;
            }
            else
            {
                rentPay = 0;
            }
            ++months; //Advance the month
        }
    }
}