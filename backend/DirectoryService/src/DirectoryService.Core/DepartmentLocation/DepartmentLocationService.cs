using DirectoryService.Core.Department;
using DirectoryService.Core.Department.Exceptions;
using DirectoryService.Core.DepartmentLocation.Exceptions;
using DirectoryService.Core.Location;
using DirectoryService.Core.Location.Exceptions;

namespace DirectoryService.Core.DepartmentLocation;

public class DepartmentLocationService : IDepartmentLocationService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IDepartmentLocationRepository _departmentLocationRepository;

    public DepartmentLocationService(
        IDepartmentRepository departmentRepository,
        ILocationRepository locationRepository,
        IDepartmentLocationRepository departmentLocationRepository)
    {
        _departmentRepository = departmentRepository;
        _locationRepository = locationRepository;
        _departmentLocationRepository = departmentLocationRepository;
    }

    public async Task<Guid> CreateLink(Guid departmentId, Guid locationId, bool isPrimary, CancellationToken ct)
    {
        if (await _departmentRepository.GetDepartmentById(departmentId, ct) == null)
            throw new DepartmentNotFoundException();

        if (await _locationRepository.GetById(locationId, ct) == null)
            throw new LocationNotFoundException();

        if (await _departmentLocationRepository.IsLinkExist(departmentId, locationId, ct))
            throw new DepartmentLocationConflictException();

        var id = await _departmentLocationRepository.CreateWithLocation(
            Domain.DepartmentLocation.Create(departmentId, locationId, isPrimary), ct);

        await _departmentLocationRepository.Save(ct);
        return id;
    }

    public async Task DeleteLink(Guid departmentId, Guid locationId, CancellationToken ct)
    {
        if (await _departmentRepository.GetDepartmentById(departmentId, ct) == null)
            throw new DepartmentNotFoundException();

        if (await _locationRepository.GetById(locationId, ct) == null)
            throw new LocationNotFoundException();

        if (!await _departmentLocationRepository.IsLinkExist(departmentId, locationId, ct))
            throw new DepartmentLocationNotFoundException();

        await _departmentLocationRepository.Delete(departmentId, locationId, ct);

        await _departmentLocationRepository.Save(ct);
    }
}
