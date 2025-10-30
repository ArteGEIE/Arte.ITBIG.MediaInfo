using System.Text.Json.Serialization;

namespace MediaInfo.Model
{
    /// <summary>
    /// Describes video transfer characteristics
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MatrixCoefficient
    {
        /// <summary>
        /// BT.709
        /// </summary>
        BT709,

        /// <summary>
        /// BT.2020 non-constant
        /// </summary>
        BT2020NonConstant,

        /// <summary>
        /// 
        /// </summary>
        Identity,

        /// <summary>
        /// 
        /// </summary>
        BT470SystemBG,

        /// <summary>
        /// 
        /// </summary>
        BT601,

        /// <summary>
        /// 
        /// </summary>
        BT2020Constant,

        /// <summary>
        /// 
        /// </summary>
        FCC73682,

        /// <summary>
        /// 
        /// </summary>
        SMPTE240M,

        /// <summary>
        /// 
        /// </summary>
        YCgCo,

        /// <summary>
        /// 
        /// </summary>
        YDzDx,

        /// <summary>
        /// 
        /// </summary>
        ChromaticityDerivedNonConstant,

        /// <summary>
        /// 
        /// </summary>
        ChromaticityDerivedConstant,

        /// <summary>
        /// 
        /// </summary>
        ICtCp
    }
}