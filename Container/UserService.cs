using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orbital_Africa_Backend_Recon.Modal;
using Orbital_Africa_Backend_Recon.Modal.Email;
using Orbital_Africa_Backend_Recon.Models;
using Orbital_Africa_Backend_Recon.Service;

namespace Orbital_Africa_Backend_Recon.Container
{
    public class UserService :IuserService
    {
        private readonly OrbitalAfricaContext context;
        private readonly IEmailService emailservice;
        private readonly IMapper mapper;
        public UserService(OrbitalAfricaContext context, IEmailService emailservice, IMapper mapper)
        {
            this.context = context;
            this.emailservice = emailservice;
            this.mapper = mapper;
        }

        public async Task<APIResponse> ConfirmRegistration(int userid, string username, string otptext)
        {
            APIResponse response = new APIResponse();
            bool otpresponse = await ValidateOTP(username, otptext);
            if (!otpresponse)
            {
                response.Result = "Failed";
                response.message = "Invalid OTP or Expired";
            }
            else
            {
                var tempdata = await this.context.TbltempUsers.FirstOrDefaultAsync(item => item.Id == userid);
                var user = new TblUser
                {
                    Username = username,
                    FirstName = tempdata.FirstName,
                    LastName = tempdata.LastName,
                    Password = tempdata.Password,
                    Email = tempdata.Email,
                    Phone = tempdata.Phone,
                    Gender = tempdata.Gender,
                    Role = tempdata.Role,
                    Status = tempdata.Status,
                    Address = tempdata.Address,
                    Islocked = false,
                    Isactive = true
                };
                if (tempdata.Role == "Customer")
                {
                    var customer = new Tblcustomer
                    {
                        CustomerId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.Tblcustomers.AddAsync(customer);
                }
                if (tempdata.Role == "Driver")
                {
                    var driver = new Tbldriver
                    {
                        DriverId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.Tbldrivers.AddAsync(driver);
                }
                if (tempdata.Role == "Service Manager")
                {
                    var servicemng = new TblserviceManager
                    {
                        ServiceManagerId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.TblserviceManagers.AddAsync(servicemng);
                }

                if (tempdata.Role == "Dispatch Manager")
                {
                    var dispatchmng = new TbldispatchManager
                    {
                        DispatchManagerId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.TbldispatchManagers.AddAsync(dispatchmng);
                }
                if (tempdata.Role == "Inventory Manager")
                {
                    var inventorymng = new TblinventoryManager
                    {
                        InventoryManagerId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.TblinventoryManagers.AddAsync(inventorymng);
                }
                if (tempdata.Role == "Supplier")
                {
                    var supplier = new Tblsupplier
                    {
                        SupplierId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.Tblsuppliers.AddAsync(supplier);
                }
                if (tempdata.Role == "Finance")
                {
                    var finance = new Tblfinace
                    {
                        FinanceId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.Tblfinaces.AddAsync(finance);
                }
                if (tempdata.Role == "Supervisor")
                {
                    var supervisor = new Tblsupervisor
                    {
                        SupervisorId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.Tblsupervisors.AddAsync(supervisor);
                }
                if (tempdata.Role == "Technician")
                {
                    var surveyor = new Tblsurveyor
                    {
                        SurveyorId = userid,
                        Username = username,
                        FirstName = tempdata.FirstName,
                        LastName = tempdata.LastName,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Status,
                        Address = tempdata.Address
                    };
                    await this.context.Tblsurveyors.AddAsync(surveyor);
                }

                await this.context.TblUsers.AddAsync(user);

                await this.context.SaveChangesAsync();
                await UpdatePwdManager(username, tempdata.Password);
                response.Result = "Pass";
                response.message = "Registered successfully";
            }
            return response;
        }

        public async Task<APIResponse> UserRegistration(UserRegister userRegister)
        {
            APIResponse response = new APIResponse();
            int userid = 0;
            bool isvalid = true;

            try
            {
                // duplicate user
                var _user = await this.context.TblUsers.Where(item => item.Username == userRegister.username).ToListAsync();
                if (_user.Count > 0)
                {
                    isvalid = false;
                    response.Result = "fail";
                    response.message = "Duplicate username";
                }

                // duplicate Email
                var _useremail = await this.context.TblUsers.Where(item => item.Email == userRegister.email).ToListAsync();
                if (_useremail.Count > 0)
                {
                    isvalid = false;
                    response.Result = "fail";
                    response.message = "Duplicate Email";
                }


                if (userRegister != null && isvalid)
                {
                    var _tempuser = new TbltempUser()
                    {
                        Username = userRegister.username,
                        FirstName = userRegister.first_name,
                        LastName = userRegister.last_name,
                        Email = userRegister.email,
                        Password = userRegister.password,
                        Phone = userRegister.phone,
                        Gender = userRegister.gender,
                        Address = userRegister.address,
                        Role = userRegister.role,
                        Status = "Inactive"
                    };
                    await this.context.TbltempUsers.AddAsync(_tempuser);
                    await this.context.SaveChangesAsync();
                    userid = _tempuser.Id;
                    string OTPText = Generaterandomnumber();
                    await UpdateOtp(userRegister.username, OTPText, "register");
                    await SendOtpMail(userRegister.email, OTPText, userRegister.username);
                    response.Result = "pass";
                    response.message = userid.ToString();
                }

            }
            catch (Exception ex)
            {
                response.Result = "fail";
            }

            return response;

        }

        //function to update the otpmanager
        public async Task UpdateOtp(string username, string otptext, string otptype)
        {
            var _otp = new TblotpManager()
            {
                Username = username,
                Otptext = otptext,
                Expiration = DateTime.Now.AddMinutes(30),
                CreateDate = DateTime.Now,
                Otpttype = otptype

            };
            await this.context.TblotpManagers.AddAsync(_otp);
            await this.context.SaveChangesAsync();
        }

        //function for generatting the otp
        private string Generaterandomnumber()
        {
            Random random = new Random();
            string randomno = random.Next(0, 1000000).ToString("D6");
            return randomno;
        }
        //FUNCTION TO SEND TO THE USEREMAIL
        private async Task SendOtpMail(string username, string useremail, string otptext)
        {
            var mailrequest = new MailRequest();
            mailrequest.Email = useremail;
            mailrequest.Subject = "Thanks for Registering: OTP";
            mailrequest.EmailBody= GenerateEmailBody(username, otptext);
            await this.emailservice.SendEmail(mailrequest);
        }

        //FUNCTION FOR GENERATING EMAILBODY
        private string GenerateEmailBody(string name,string otptext)
        {
            string emailbody = "<div style='width:100; background-color=grey'>";
            emailbody += "<h1>Hi" + name + ", Thanks for registering </h1>";
            emailbody += "<h2>OTPText is:" + otptext + "</h2>";
            emailbody += "</div>";
            return emailbody;
        }

        //function to validate OTP
        public async Task<bool> ValidateOTP(string username, string OTPText)
        {
            bool response = false;
            var data = await this.context.TblotpManagers.FirstOrDefaultAsync(item => item.Username == username && item.Otptext == OTPText && item.Expiration > DateTime.Now);
            if (data != null)
            {
                response = true;
            }
            return response;
        }

        //function to update the password manager
        private async Task UpdatePwdManager(string username, string password)
        {
            var _opt = new TblpwdManager()
            {
                Username = username,
                Password = password,
                Modifydate = DateTime.Now
            };
            await this.context.TblpwdManagers.AddAsync(_opt);
            await this.context.SaveChangesAsync();
        }





        public async Task<APIResponse> ResetPassword(string username, string oldpassword, string newpassword)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.TblUsers.FirstOrDefaultAsync(item => item.Username == username && item.Password == oldpassword && item.Isactive == true);
            if (user != null)
            {
                var _pwdhistory = await ValidatePWDHistory(username, newpassword);
                if (_pwdhistory)
                {
                    response.Result = "Failed";
                    response.message = "Don't use the same password used in the last 3 transactions";
                }
                else
                {
                    user.Password = newpassword;
                    await this.context.SaveChangesAsync();
                    await UpdatePwdManager(username, newpassword);
                    response.Result = "Pass";
                    response.message = "Password changed successfully";
                }
            }
            else
            {
                response.Result = "Failed";
                response.ErrorMessage = "Failed to validate old password";
            }
            return response;
        }
        //function to validate the password history
        private async Task<bool> ValidatePWDHistory(string username, string password)
        {
            bool response = false;
            var pwd = await this.context.TblpwdManagers.Where(item => item.Username == username).
                OrderByDescending(p => p.Modifydate).Take(3).ToListAsync();
            if (pwd.Count > 0)
            {
                var validate = pwd.Where(o => o.Password == password);
                if (validate.Any())
                {
                    response = true;
                }
            }
            return response;
        }

        public async Task<APIResponse> ForgotPassword(string username)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.TblUsers.FirstOrDefaultAsync(item => item.Username == username && item.Isactive == true);
            if (user != null)
            {
                string otptext = Generaterandomnumber();
                await UpdateOtp(username, otptext, "Forgot password");
                await SendOtpMail(user.Email, otptext, username);
                response.Result = "Pass";
                response.message = "OTP sent";
            }
            else
            {
                response.Result = "Failed";
                response.message = "Invalid user";
            }
            return response;
        }

        public async Task<APIResponse> UpdatePassword(string username, string password, string otptext)
        {
            APIResponse response = new APIResponse();
            bool otpvalidation = await ValidateOTP(username, otptext);
            if (otpvalidation)
            {
                bool pwdhistory = await ValidatePWDHistory(username, password);
                if (pwdhistory)
                {
                    response.Result = "Fail";
                    response.message = "Don't use similar passwords for 3 consecutive transactions";
                }
                else
                {
                    var user = await this.context.TblUsers.FirstOrDefaultAsync(item => item.Username == username && item.Isactive == true);
                    if (user != null)
                    {
                        user.Password = password;
                        await this.context.SaveChangesAsync();
                        await UpdatePwdManager(username, password);
                        response.Result = "Pass";
                        response.message = "Password changed successfully";
                    }
                    else
                    {
                        response.Result = "Fail";
                        response.message = "Invalid OTP";
                    }
                }
            }
            return response;
        }

        public async Task<APIResponse> UpdateStatus(string username, bool userstatus)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.TblUsers.FirstOrDefaultAsync(item => item.Username == username);
            if (user != null)
            {
                user.Isactive = userstatus;
                await this.context.SaveChangesAsync();
                response.Result = "Pass";
                response.message = "User status changed";
            }
            else
            {
                response.Result = "Failed";
                response.message = "Invalid user";
            }
            return response;
        }

        public async Task<APIResponse> UpdateRole(string username, string userrole)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.TblUsers.FirstOrDefaultAsync(item => item.Username == username && item.Isactive == true);
            if (user != null)
            {
                user.Role = userrole;
                await this.context.SaveChangesAsync();
                response.Result = "Pass";
                response.message = "User status changed";
            }
            else
            {
                response.Result = "Failed";
                response.message = "Invalid user";
            }
            return response;
        }

        public async Task<APIResponse> CustomerRegistration(CustomerRegister customer)
        {
            APIResponse response = new APIResponse();
            int userid = 0;
            bool isvalid = true;
            try
            {
                //Duplicate user
                var _customer = await this.context.TblUsers.Where(item => item.Username == customer.username).ToListAsync();
                if (_customer.Count > 0)
                {
                    isvalid = false;
                    response.Result = "Failed";
                    response.message = "Duplicate username";
                }

                //Duplicate useremail
                var customeremail = await this.context.TblUsers.Where(item => item.Email == customer.email).ToListAsync();
                if (customeremail.Count > 0)
                {
                    isvalid = false;
                    response.Result = "Failed";
                    response.message = "Duplicate Email";
                }
                if (customer != null)
                {
                    var _tempuser = new TbltempUser()
                    {
                        Username = customer.username,
                        FirstName = customer.firstname,
                        LastName = customer.lastname,
                        Email = customer.email,
                        Password = customer.password,
                        Phone = customer.phone,
                        Gender = customer.gender,
                        Address = customer.address,
                        Role = "Customer",
                        Status = "Inactive"
                    };
                    await this.context.TbltempUsers.AddAsync(_tempuser);
                    await this.context.SaveChangesAsync();
                    string OTPText = Generaterandomnumber();
                    await UpdateOtp(customer.username, OTPText, "Register");
                    await SendOtpMail(customer.username, OTPText, customer.email);
                    userid = _tempuser.Id;
                    response.Result = "Pass";
                    response.ResponseCode = userid.ToString();
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Fail";
            }
            return response;
        }

        public async Task<List<UserModal>> GetUsers()
        {
            List<UserModal> _response = new List<UserModal>();
            var _data = await this.context.TblUsers.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblUser>, List<UserModal>>(_data);
            }
            return _response;
        }
    
    }
}

