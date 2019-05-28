using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Shared.Test.Responses
{
    public class ImageArrayShort2DResponseIsInitialisedWith
    {
        [Fact]
        public void Rank2_And_TypeShort()
        {
            var response = new ImageArrayShort2DResponse(new short[1,1]);
            
            Assert.Equal(ImageArrayRank.SinglePlane, response.Rank);
            Assert.Equal(ImageArrayType.Short, response.ArrayType);
        }
    }
}