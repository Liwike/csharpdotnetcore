using l2l.Data.Model;

namespace l2l.Data.Tests
{
    public class DataBaseFixture : System.IDisposable
    {
        public DataBaseFixture()
        {
          var facrory = new L2LDbContextFactory();
          //r db=factory.C   
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}