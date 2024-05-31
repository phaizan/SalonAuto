using Logic.DtoModels.Filters;
using SalonAuto.Features.DtoModels.Center;

namespace SalonAuto.Features.Interfaces.Managers
{
    public interface ICenterManager
    {
        void Create(EditCenter editCenter);

        void Update(EditCenter updateCenter);

        void Delete(Guid isnNode);
        CenterDto GetCenter(Guid isnNode);

        CenterDto[] GetListCenters(CenterFilterDto centerFilter);
    }
}
