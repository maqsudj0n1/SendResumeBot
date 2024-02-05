namespace SendResumeBot.BizLogicLayer.Services;

public class CheckUserNameDto
{
    public int? Id { get; set; }
    public string UserName { get; set; }
} 

public class CheckUserNameRespDto
{
    public string UserName { get; set; }
    public bool IsBusy { get; set; }
}
