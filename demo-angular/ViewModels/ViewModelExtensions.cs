using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class ViewModelExtensions
    {
        public static ViewModels.Widget ToViewModel(this Models.Widget model)
        {
            ViewModels.Widget result = null;

            if (model != null) {

                result = new ViewModels.Widget();


                result.Id = model.Id.ToString();
                result.Name = model.Name;
            }

            return result;
        }

        public static Models.Widget FromViewModel(this ViewModels.Widget viewModel)
        {
            Models.Widget result = null;

            if (viewModel != null)
            {

                result = new Models.Widget();
                result.Id = new MongoDB.Bson.ObjectId(viewModel.Id);
                result.Name = viewModel.Name;
            }

            return result;
        }
    }
}
