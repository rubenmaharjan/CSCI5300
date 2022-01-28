using System;

namespace OrchestraLib
{
	public class Orchestra
	{
		private int _Id;
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _AddressLine1;
		public string AddressLine1
		{
			get { return _AddressLine1; }
			set { _AddressLine1 = value; }
		}

		private string _AddressLine2;
		public string AddressLine2
		{
			get { return _AddressLine2; }
			set { _AddressLine2 = value; }
		}

		private string _City;
		public string City
		{
			get { return _City; }
			set { _City = value; }
		}

		private string _State;
		public string State
		{
			get { return _State; }
			set { _State = value; }
		}

		private string _ZipCode;
		public string ZipCode
		{
			get { return _ZipCode; }
			set { _ZipCode = value; }
		}

		private string _WebsiteURL;
		public string WebsiteURL
		{
			get { return _WebsiteURL; }
			set { _WebsiteURL = value; }
		}

		public Orchestra()
		{ }

		public Orchestra(int Id_, string Name_, string AddressLine1_, string AddressLine2_, string City_, string State_, string ZipCode_, string WebsiteURL_)
		{
			this.Id = Id_;
			this.Name = Name_;
			this.AddressLine1 = AddressLine1_;
			this.AddressLine2 = AddressLine2_;
			this.City = City_;
			this.State = State_;
			this.ZipCode = ZipCode_;
			this.WebsiteURL = WebsiteURL_;
		}
	}
}
