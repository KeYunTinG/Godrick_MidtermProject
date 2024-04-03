using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slnMumu_MidtermProject.Query
{
    public class QueryDB
    {
        private ZecZecEntities db = new ZecZecEntities();
        public async Task<Members> FindMember(string username)
        {
            Members member = await Task.Run(() => db.Members.FirstOrDefault(x => x.Username == username));

            return member;
        }

        public async Task<Members> FindMember(int memberID)
        {
            Members member = await Task.Run(() => db.Members.FirstOrDefault(x => x.MemberID == memberID));

            return member;
        }

        public class ProjectsProducts
        {
            public Projects project { get; set; }
            public Products product { get; set; }
        }

        public async Task<List<ProjectsProducts>> FindDataWithProjectID(int projectID)
        {
            var result = await Task.Run(() => db.Projects.Join(db.Products, pj => pj.ProjectID, pd => pd.ProjectID, (pj, pd) => new ProjectsProducts { project = pj, product = pd }).Where(x => x.project.ProjectID == projectID).ToListAsync());

            return result;
        }

        public class ProjectJoinProjectIDTypeJoinProjectTypes
        {
            public string projectName { get; set; }
        }

        public async Task<List<ProjectJoinProjectIDTypeJoinProjectTypes>> FindProjectType(int projectID)
        {
            var result = await Task.Run(() => db.Projects.Join(db.ProjectIDType, pj => pj.ProjectID, pt => pt.ProjectID, (pj, pt) => new { pj.ProjectID, pt.ProjectTypeID }).Where(x => x.ProjectID == projectID).Join(db.ProjectTypes, temp => temp.ProjectTypeID, pt => pt.ProjectTypeID, (temp, pt) => new ProjectJoinProjectIDTypeJoinProjectTypes { projectName = pt.ProjectTypeName }).ToListAsync());

            return result;
        }

        public async Task<List<Products>> FindProductsWithProjectID(int projectID)
        {
            var result = await Task.Run(() => db.Products.Where(x => x.ProjectID == projectID).ToListAsync());

            return result;
        }

        public async Task<Products> FindProductWithProductID(int productID)
        {
            Products result = await Task.Run(() => db.Products.FirstOrDefault(x => x.ProductID == productID));

            return result;
        }

        public class ProjectsProductsOrderDetails
        {
            public decimal price { get; set; }
            public decimal goal { get; set; }
        }

        public async Task<List<ProjectsProductsOrderDetails>> ProjJoinProdJoinOD(int projectID)
        {
            var result = await Task.Run(() => db.Projects.Join(db.Products, x => x.ProjectID, y => y.ProjectID, (x, y) => new { x.ProjectID, x.Goal, y.ProductID, y.Price }).Where(z => z.ProjectID == projectID).Join(db.OrderDetails, x => x.ProductID, y => y.ProductID, (x, y) => new ProjectsProductsOrderDetails { goal = x.Goal, price = y.Price }).ToListAsync());

            return result;
        }
    }
}
