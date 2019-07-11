﻿using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace CodeStream.VisualStudio.Services {
	public interface ICredentialsService {
		Task<Tuple<string, string>> LoadAsync(Uri uri, string email);
		Task<bool> SaveAsync(Uri uri, string email, string secret);
		Task<bool> SaveJsonAsync(Uri uri, string email, JToken secret);
		Task<bool> DeleteAsync(Uri uri, string email);
		Task<JToken> LoadJsonAsync(Uri uri, string email);
	}

	[Export(typeof(ICredentialsService))]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public class CredentialsService : CredentialsServiceBase, ICredentialsService {
		public Task<Tuple<string, string>> LoadAsync(Uri uri, string email) {
			return LoadAsync(uri.ToString(), email);
		}

		public Task<JToken> LoadJsonAsync(Uri uri, string email) {
			return base.LoadJsonAsync(uri.ToString(), email);
		}

		public Task<bool> SaveAsync(Uri uri, string email, string secret) {
			return SaveAsync(email, secret, uri.ToString(), email);
		}

		public Task<bool> SaveJsonAsync(Uri uri, string email, JToken secret) {
			return SaveAsync(email, secret.ToString(Newtonsoft.Json.Formatting.None), uri.ToString(), email);
		}

		public Task<bool> DeleteAsync(Uri uri, string email) {
			return DeleteAsync(uri.ToString(), email);
		}
	}
}