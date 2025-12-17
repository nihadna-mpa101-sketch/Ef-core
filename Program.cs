using ConsoleApp21;
using Microsoft.EntityFrameworkCore;

using AppDbContext context = new AppDbContext();
while (true)
{
    Console.WriteLine("1.Group yarat");
    Console.WriteLine("2.Grouplari goster");
    Console.WriteLine("3.Group sil");
    Console.WriteLine("4.Student yarat");
    Console.WriteLine("5.Studentleri goster");
    Console.WriteLine("6.Student sil");
start:

    Console.Write("Secim: ");
    int secim = int.Parse(Console.ReadLine());
    Console.Clear();
    switch (secim)
    {
        case 1:
            Console.Write("Group adi: ");
            string gname = Console.ReadLine();

            context.Groups.Add(new Group { Name = gname });
            context.SaveChanges();
            Console.WriteLine("Group yaradildi");
            break;

        case 2:
            var groups = context.Groups.ToList();
            foreach (var g in groups)
            {
                Console.WriteLine(groups);
            }
            break;

        case 3:
            Console.Write("Group Id: ");
            string gidInput = Console.ReadLine();
            bool isGid=int.TryParse(gidInput, out int gid);
            if (!isGid)
            {
                                Console.WriteLine("duzgun deyer daxil et");
                break;
            }
            Group deleteg=context.Groups.FirstOrDefault(s=>s.Id==gid);
            if(deleteg is null)
            {
                Console.WriteLine("Silmek istediyiniz Group yoxdur");
                break;
            }
            context.Groups.Remove(deleteg);
            context.SaveChanges();
            Console.WriteLine("Student silindi."); break;

        case 4:
        adinput:
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            if(ad==null||ad.Length<3)
            {
                Console.WriteLine("Ad minimum 3 simvol olmalidir");
                goto adinput;
            }
        ageInput:
            Console.Write("Age: ");
            string ageInput = Console.ReadLine();
            var resultage=int.TryParse(ageInput, out int age);    
            if(!resultage||age<0)
            {
                Console.WriteLine("duzgun deyer daxil et");
                goto ageInput;  
            }
            gradeInput:
            Console.Write("Grade: ");
            string gradeInput = Console.ReadLine();
            var resultgrade=decimal.TryParse(gradeInput, out decimal grade);
            if(!resultgrade||grade<0||grade>100)
            {
                Console.WriteLine("duzgun deyer daxil et");
                goto gradeInput;
            }

            var groupsList = context.Groups.ToList();
            groupsList.ForEach(g => Console.WriteLine(g));
        groupIdInput:
            Console.Write("Group Id: ");
            string groupIdInput = Console.ReadLine();
            var resultgroupid=int.TryParse(groupIdInput, out int groupId);
            if(!resultgroupid||groupId<0)
            {
                Console.WriteLine("duzgun deyer daxil et");
                goto groupIdInput;
            }


            Student student=new Student()
            {
                Name = ad,
                Age = age,
                Grade = grade,
                GroupId = groupId
            };
            context.Students.Add(student);
            context.SaveChanges();

            context.SaveChanges();
            Console.WriteLine("Student yaradildi");
            break;

        case 5:
            var students = context.Students.Include(s => s.Group).ToList();
            students.ForEach(student => Console.WriteLine(student));
            break;

        case 6:
            var students1 = context.Students.Include(s => s.Group).ToList();
            students1.ForEach(student => Console.WriteLine(student));

            Console.Write("Student Id: ");
            string sidInput = Console.ReadLine();
            bool isSid=int.TryParse(sidInput, out int sid);
            if (!isSid)
            {
                                Console.WriteLine("duzgun deyer daxil et");
                break;
            }
            Student deleteStudent=context.Students.FirstOrDefault(s=>s.Id==sid);
            if(deleteStudent is null)
            {
                Console.WriteLine("Silmek istediyiniz Student yoxdur");
                break;
            }
            context.Students.Remove(deleteStudent);
            context.SaveChanges();
            Console.WriteLine("Student silindi.");
            break;
        default:
            break;
    }
            goto start; 
}