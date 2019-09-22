﻿namespace Domain
{
	public class Costumer
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public bool IsValid => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);
	}
}
