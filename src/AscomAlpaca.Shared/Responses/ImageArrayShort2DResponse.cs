namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageArrayShort2DResponse : CommandResponse, IImageResponse<short[,]>
    {
        /// <summary>
        /// 
        /// </summary>
        public short[,] Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ImageArrayType ArrayType { get; } = ImageArrayType.Short;

        /// <summary>
        /// 
        /// </summary>
        public int Rank { get; } = 2;
    }
}