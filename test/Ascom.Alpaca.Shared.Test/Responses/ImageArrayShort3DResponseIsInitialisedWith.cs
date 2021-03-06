using ES.Ascom.Alpaca.Responses;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Responses
{
    public class ImageArrayShort3DResponseIsInitialisedWith
    {
        [Fact]
        public void ImageArrayShort3DResponse_IsInitialisedWith_Rank2_And_TypeShort()
        {
            var response = new ImageArrayShort3DResponse(new short[1,1,1]);
            
            Assert.Equal(ImageArrayRank.MultiPlane, response.Rank);
            Assert.Equal(ImageArrayType.Short, response.ArrayType);
        }
    }
}