// <auto-generated/>
using System;


namespace Telegram.Api.TL
{
	public partial class TLMessage : TLMessageBase 
	{
		[Flags]
		public enum Flag : Int32
		{
			Out = (1 << 1),
			Mentioned = (1 << 4),
			MediaUnread = (1 << 5),
			Silent = (1 << 13),
			Post = (1 << 14),
			FromId = (1 << 8),
			FwdFrom = (1 << 2),
			ViaBotId = (1 << 11),
			ReplyToMsgId = (1 << 3),
			Media = (1 << 9),
			ReplyMarkup = (1 << 6),
			Entities = (1 << 7),
			Views = (1 << 10),
			EditDate = (1 << 15),
			PostAuthor = (1 << 16),
			GroupedId = (1 << 17),
		}

		public bool HasFromId { get { return Flags.HasFlag(Flag.FromId); } set { Flags = value ? (Flags | Flag.FromId) : (Flags & ~Flag.FromId); } }
		public bool HasFwdFrom { get { return Flags.HasFlag(Flag.FwdFrom); } set { Flags = value ? (Flags | Flag.FwdFrom) : (Flags & ~Flag.FwdFrom); } }
		public bool HasViaBotId { get { return Flags.HasFlag(Flag.ViaBotId); } set { Flags = value ? (Flags | Flag.ViaBotId) : (Flags & ~Flag.ViaBotId); } }
		public bool HasReplyToMsgId { get { return Flags.HasFlag(Flag.ReplyToMsgId); } set { Flags = value ? (Flags | Flag.ReplyToMsgId) : (Flags & ~Flag.ReplyToMsgId); } }
		public bool HasMedia { get { return Flags.HasFlag(Flag.Media); } set { Flags = value ? (Flags | Flag.Media) : (Flags & ~Flag.Media); } }
		public bool HasReplyMarkup { get { return Flags.HasFlag(Flag.ReplyMarkup); } set { Flags = value ? (Flags | Flag.ReplyMarkup) : (Flags & ~Flag.ReplyMarkup); } }
		public bool HasEntities { get { return Flags.HasFlag(Flag.Entities); } set { Flags = value ? (Flags | Flag.Entities) : (Flags & ~Flag.Entities); } }
		public bool HasViews { get { return Flags.HasFlag(Flag.Views); } set { Flags = value ? (Flags | Flag.Views) : (Flags & ~Flag.Views); } }
		public bool HasEditDate { get { return Flags.HasFlag(Flag.EditDate); } set { Flags = value ? (Flags | Flag.EditDate) : (Flags & ~Flag.EditDate); } }
		public bool HasPostAuthor { get { return Flags.HasFlag(Flag.PostAuthor); } set { Flags = value ? (Flags | Flag.PostAuthor) : (Flags & ~Flag.PostAuthor); } }
		public bool HasGroupedId { get { return Flags.HasFlag(Flag.GroupedId); } set { Flags = value ? (Flags | Flag.GroupedId) : (Flags & ~Flag.GroupedId); } }

		public Flag Flags { get; set; }
		public TLMessageMediaBase Media { get; set; }
		public Int64? GroupedId { get; set; }

		public TLMessage() { }

		

	}
}