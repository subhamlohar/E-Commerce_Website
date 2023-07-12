using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SubhamBook.Utility
{
	public class EmailSender : IEmailSender
	{
		//logic to send email
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			return Task.CompletedTask;
		}
	}
}
