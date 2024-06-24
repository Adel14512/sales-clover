namespace Evaluation.UI.Authentication
{
	public interface ITokenService
	{
		string ExtendTokenExpiration(string existingToken);
	}
}
