namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Tests.Unit.SignedTransactionMocks
{
    public class SignedTransactionTests
    {
        private AppStoreSignedTransactionFactory _appStoreSignedTransactionFactory;

        [SetUp]
        public void Setup()
        {
            _appStoreSignedTransactionFactory = new AppStoreSignedTransactionFactory();
        }

        [Test]
        public async Task BuildTestSignedTransactionAsync_IsNotNull()
        {
            var jws = await _appStoreSignedTransactionFactory.BuildTestSignedTransactionAsync();

            Assert.IsNotNull(jws);
        }
    }
}
