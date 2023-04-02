using Wifi.Domain.Entity;
using WifiNFC.Api.DTO;

namespace WifiNFC.Api.Services.Mapper
{
    public class DTOMapper : IDTOMapper
    {
        public DTOCleaning CleaningToDTO(Cleaning cleaning)
        {
            return new(cleaning.TimeOfCleaning, cleaning.Room.Name, cleaning.Note);
        }

        public DTOCleaning[] CleaningToDTO(Cleaning[] cleaning)
        {
            var temp = new DTOCleaning[cleaning.Length];
            for (int i = 0; i < cleaning.Length; i++)
            {
                temp[i] = CleaningToDTO(cleaning[i]);
            }
            return temp;

        }
    }
}
