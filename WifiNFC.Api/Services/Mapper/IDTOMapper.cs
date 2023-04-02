using Wifi.Domain.Entity;
using WifiNFC.Api.DTO;

namespace WifiNFC.Api.Services.Mapper
{
    public interface IDTOMapper
    {
        DTOCleaning CleaningToDTO(Cleaning cleaning);
        DTOCleaning[] CleaningToDTO(Cleaning[] cleaning);
    }
}
