namespace AirTickedSales.ViewModel.Catalog.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObject)
        {
            IsSuccessed = true;
            ResultObject = resultObject;
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}
