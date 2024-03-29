using Leelite.Framework.Service.Dtos;

namespace Leelite.MessageCenter.Dtos.PushRecordDtos
{
    public class PushRecordDto : IDto<long>
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public int PlatformId { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public bool PushState { get; set; }

        public int RetriesNum { get; set; }

        public string Remark { get; set; }

    }
}
