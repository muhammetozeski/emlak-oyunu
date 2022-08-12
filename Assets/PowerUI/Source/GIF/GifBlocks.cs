//--------------------------------------//			   PowerUI////		For documentation or //	if you have any issues, visit//		powerUI.kulestar.com////	Copyright © 2013 Kulestar Ltd//		  www.kulestar.com//--------------------------------------namespace Gif{	/// <summary>	/// Blocks in a GIF stream.	/// </summary>	public static class GifBlocks{				/// <summary>		/// Extension Introducer		/// </summary>		  		public const byte ExtensionIntroducer = 0x21;				/// <summary>		/// lock Terminator		/// </summary>		public const byte Terminator = 0;				/// <summary>		/// Application Extension Label		/// </summary>		public const byte ApplicationExtensionLabel = 0xFF;				/// <summary>		/// Comment Label		/// </summary>		public const byte CommentLabel = 0xFE;				/// <summary>		/// Image info next.		/// </summary>		public const byte ImageDescriptorLabel = 0x2C;		/// <summary>		/// Plain Text Label		/// </summary>		public const byte PlainTextLabel = 0x01;		/// <summary>		/// Graphic Control Label		/// </summary>		public const byte GraphicControlLabel = 0xF9;		/// <summary>		/// Image is next.		/// </summary>		public const byte ImageLabel = 0x2C;				/// <summary>		/// Terminal.		/// </summary>		public const byte EndIntroducer = 0x3B;			}	}