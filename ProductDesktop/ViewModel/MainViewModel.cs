namespace ProductDesktop.ViewModel
{
    public class MainViewModel
    {
        public StaffViewModel StaffViewModel { get; }

        public EnumViewModel EnumViewModel { get; }
        public MainViewModel(EnumViewModel enumModel, StaffViewModel staffModel)
        {
            EnumViewModel = enumModel;
            StaffViewModel = staffModel;
        }
    }
}
