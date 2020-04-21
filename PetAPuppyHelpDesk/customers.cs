using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAPuppyHelpDesk
{
    //Customer class with attributes submitted by user.
    public class customer
    {
        public string userName;
        public string firstName;
        public string lastName;
        public string password;
        public string email;
        public string address;
        public string city;
        public string state;
        public string phoneNumber;
        public string zip;
        public string phoneType;
        public string askForTexts;

        //Set first name
        public void SetFirstName(string firstNameInput)
        {
            firstName = firstNameInput;
        }

        //Set last name
        public void SetLastName(string lastNameInput)
        {
            lastName = lastNameInput;
        }

        //Set username
        public void SetUserName(string UserNameInput)
        {
            userName = UserNameInput;
        }

        //Set password
        public void SetPassword(string passwordInput)
        {
            password = passwordInput;
        }

        //Set email
        public void SetEmail(string emailInput)
        {
            email = emailInput;
        }

        //Set address
        public void SetAddress(string addressInput)
        {
            address = addressInput;
        }

        //Set city
        public void SetCity(string cityInput)
        {
            city = cityInput;
        }

        //Set state
        public void SetState(string stateInput)
        {
            state = stateInput;
        }

        //Set phone number
        public void SetPhoneNumber(string phoneNumberInput)
        {
            phoneNumber = phoneNumberInput;
        }

        //Set zip code
        public void SetZip(string zipInput)
        {
            zip = zipInput;
        }

        //Set if user wants to receive texts
        public void SetAskForTexts(string askForTextsInput)
        {
            askForTexts = askForTextsInput;
        }

        //Set phone type
        public void SetPhoneType(string phoneTypeInput)
        {
            phoneType = phoneTypeInput;
        }

        //Get first name
        public string GetFirstName()
        {
            return firstName;
        }

        //Get last name
        public string GetLastName()
        {
            return lastName;
        }

        //Get username
        public string GetUserName()
        {
            return userName;
        }

        //Get password
        public string GetPassword()
        {
            return password;
        }

        //Get email address
        public string GetEmail()
        {
            return email;
        }

        //Get address
        public string GetAddress()
        {
            return address;
        }

        //Get city
        public string GetCity()
        {
            return city;
        }

        //Get state
        public string GetState()
        {
            return state;
        }

        //Get phone number
        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        //Get zip code
        public string GetZip()
        {
            return zip;
        }

        //Get phone type
        public string GetPhoneType()
        {
            return phoneType;
        }

        //Get user's response to texts question
        public string GetAskForTexts()
        {
            return askForTexts;
        }
    }
}