using Master.Domain.DTO.PermissionDTOs;
using Master.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Repository
{
    public interface IPermission
    {
        void AddPermission(AddPermissionDTO permission);

        void DeletePermission(int id);

        List<FetchPermissionDTO> ViewPermissions();

        FetchPermissionDTO FetchPermissionById(int id);


    }
}
