using Riok.Mapperly.Abstractions;

namespace Application.Mapping;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class MappingProfile
{
    //public partial BetDto MapBetToBetDto(Bet bet);

    //public partial Bet MapBetDtoToBet(BetDto bet);
}