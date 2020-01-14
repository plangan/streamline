using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StreamLineModels.Models;

namespace StreamLineModels
{
    public partial class IcecapContext : DbContext
    {
        public IcecapContext(DbContextOptions<IcecapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysErrors> SysErrors { get; set; }
        public virtual DbSet<TblActivitystatus> TblActivitystatus { get; set; }
        public virtual DbSet<TblAudit> TblAudit { get; set; }
        public virtual DbSet<TblAuditTypes> TblAuditTypes { get; set; }
        public virtual DbSet<TblChild> TblChild { get; set; }
        public virtual DbSet<TblCtry> TblCtry { get; set; }
        public virtual DbSet<TblCtuStatus> TblCtuStatus { get; set; }
        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblDistType> TblDistType { get; set; }
        public virtual DbSet<TblDocuments> TblDocuments { get; set; }
        public virtual DbSet<TblEmailGroups> TblEmailGroups { get; set; }
        public virtual DbSet<TblEmailGrpMdtls> TblEmailGrpMdtls { get; set; }
        public virtual DbSet<TblEmailGrpMembers> TblEmailGrpMembers { get; set; }
        public virtual DbSet<TblEmailText> TblEmailText { get; set; }
        public virtual DbSet<TblFeedback> TblFeedback { get; set; }
        public virtual DbSet<TblFiles> TblFiles { get; set; }
        public virtual DbSet<TblFilters> TblFilters { get; set; }
        public virtual DbSet<TblGrandchild> TblGrandchild { get; set; }
        public virtual DbSet<TblGreatgrandchild> TblGreatgrandchild { get; set; }
        public virtual DbSet<TblImages> TblImages { get; set; }
        public virtual DbSet<TblInstImages> TblInstImages { get; set; }
        public virtual DbSet<TblInstitutiondetails> TblInstitutiondetails { get; set; }
        public virtual DbSet<TblInstpeople> TblInstpeople { get; set; }
        public virtual DbSet<TblJobtitle> TblJobtitle { get; set; }
        public virtual DbSet<TblKeydocs> TblKeydocs { get; set; }
        public virtual DbSet<TblLocalStatus> TblLocalStatus { get; set; }
        public virtual DbSet<TblMessages> TblMessages { get; set; }
        public virtual DbSet<TblParent> TblParent { get; set; }
        public virtual DbSet<TblPatient> TblPatient { get; set; }
        public virtual DbSet<TblPersondetails> TblPersondetails { get; set; }
        public virtual DbSet<TblPrivileges> TblPrivileges { get; set; }
        public virtual DbSet<TblQuestionGrp> TblQuestionGrp { get; set; }
        public virtual DbSet<TblQuestionPool> TblQuestionPool { get; set; }
        public virtual DbSet<TblQuestionType> TblQuestionType { get; set; }
        public virtual DbSet<TblQuestionaire> TblQuestionaire { get; set; }
        public virtual DbSet<TblQuestionaireAnswers> TblQuestionaireAnswers { get; set; }
        public virtual DbSet<TblReceivedstatus> TblReceivedstatus { get; set; }
        public virtual DbSet<TblResponsestatus> TblResponsestatus { get; set; }
        public virtual DbSet<TblSpareData> TblSpareData { get; set; }
        public virtual DbSet<TblSpareDefn> TblSpareDefn { get; set; }
        public virtual DbSet<TblSpareEnum> TblSpareEnum { get; set; }
        public virtual DbSet<TblSpareTypes> TblSpareTypes { get; set; }
        public virtual DbSet<TblSponsorStatus> TblSponsorStatus { get; set; }
        public virtual DbSet<TblStudyinst> TblStudyinst { get; set; }
        public virtual DbSet<TblStudypeople> TblStudypeople { get; set; }
        public virtual DbSet<TblStudyrole> TblStudyrole { get; set; }
        public virtual DbSet<TblStudystatus> TblStudystatus { get; set; }
        public virtual DbSet<TblStudytypes> TblStudytypes { get; set; }
        public virtual DbSet<TblSysupdate> TblSysupdate { get; set; }
        public virtual DbSet<TblTempDetail> TblTempDetail { get; set; }
        public virtual DbSet<TblTemplate> TblTemplate { get; set; }
        public virtual DbSet<TblText> TblText { get; set; }
        public virtual DbSet<TblTitle> TblTitle { get; set; }
        public virtual DbSet<TblTrash> TblTrash { get; set; }
        public virtual DbSet<TblTrialdetails> TblTrialdetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysErrors>(entity =>
            {
                entity.ToTable("sys_errors");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Msg)
                    .HasColumnName("msg")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TblActivitystatus>(entity =>
            {
                entity.ToTable("tbl_activitystatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblAudit>(entity =>
            {
                entity.ToTable("tbl_audit");

                entity.HasIndex(e => e.Datim)
                    .HasName("audit_I1");

                entity.HasIndex(e => e.Typ)
                    .HasName("audit_I2");

                entity.HasIndex(e => new { e.Typ, e.Datim })
                    .HasName("audit_I3");

                entity.HasIndex(e => new { e.UserId, e.Typ })
                    .HasName("audit_I4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("text");

                entity.Property(e => e.AfterData)
                    .HasColumnName("after_data")
                    .HasColumnType("text");

                entity.Property(e => e.BeforeData)
                    .HasColumnName("before_data")
                    .HasColumnType("text");

                entity.Property(e => e.Datim)
                    .HasColumnName("datim")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblAuditTypes>(entity =>
            {
                entity.ToTable("tbl_audit_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<TblChild>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.Id })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_child");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblCtry>(entity =>
            {
                entity.ToTable("tbl_ctry");

                entity.HasIndex(e => e.Active)
                    .HasName("ctry_I2");

                entity.HasIndex(e => new { e.Id, e.Active })
                    .HasName("ctry_I1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblCtuStatus>(entity =>
            {
                entity.ToTable("tbl_ctu_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => new { e.InstId, e.DeptId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_department");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Nam)
                    .HasColumnName("nam")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TelNo)
                    .HasColumnName("tel_no")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblDistType>(entity =>
            {
                entity.ToTable("tbl_dist_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<TblDocuments>(entity =>
            {
                entity.ToTable("tbl_documents");

                entity.HasIndex(e => e.Active)
                    .HasName("documents_I12");

                entity.HasIndex(e => e.CtuApprBy)
                    .HasName("documents_I6");

                entity.HasIndex(e => e.CtuStatusId)
                    .HasName("documents_I3");

                entity.HasIndex(e => e.DistTypeId)
                    .HasName("documents_I13");

                entity.HasIndex(e => e.Filename)
                    .HasName("documents_I9");

                entity.HasIndex(e => e.InstId)
                    .HasName("documents_I2");

                entity.HasIndex(e => e.Location)
                    .HasName("documents_I10");

                entity.HasIndex(e => e.ParentId)
                    .HasName("documents_I14");

                entity.HasIndex(e => e.SiteApprBy)
                    .HasName("documents_I7");

                entity.HasIndex(e => e.SiteStatusId)
                    .HasName("documents_I8");

                entity.HasIndex(e => e.SponsorStatusId)
                    .HasName("documents_I11");

                entity.HasIndex(e => e.StudyId)
                    .HasName("documents_I1");

                entity.HasIndex(e => e.UploadedBy)
                    .HasName("documents_I5");

                entity.HasIndex(e => new { e.StudyId, e.UploadedBy })
                    .HasName("documents_I4");

                entity.HasIndex(e => new { e.StudyId, e.InstId, e.DistTypeId })
                    .HasName("documents_I15");

                entity.HasIndex(e => new { e.StudyId, e.InstId, e.Location, e.Active })
                    .HasName("documents_I16");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.CtuApprBy)
                    .HasColumnName("ctu_appr_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CtuApprDate)
                    .HasColumnName("ctu_appr_date")
                    .HasColumnType("date");

                entity.Property(e => e.CtuStatusId)
                    .HasColumnName("ctu_status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("text");

                entity.Property(e => e.DistNumTimes)
                    .HasColumnName("dist_num_times")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistTypeId)
                    .HasColumnName("dist_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SiteApprBy)
                    .HasColumnName("site_appr_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SiteApprDate)
                    .HasColumnName("site_appr_date")
                    .HasColumnType("date");

                entity.Property(e => e.SiteStatusId)
                    .HasColumnName("site_status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Spare01)
                    .HasColumnName("spare01")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare01lbl)
                    .HasColumnName("spare01lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare02)
                    .HasColumnName("spare02")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare02lbl)
                    .HasColumnName("spare02lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare03)
                    .HasColumnName("spare03")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare03lbl)
                    .HasColumnName("spare03lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.SponsorApprBy)
                    .HasColumnName("sponsor_appr_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SponsorApprDate)
                    .HasColumnName("sponsor_appr_date")
                    .HasColumnType("date");

                entity.Property(e => e.SponsorStatusId)
                    .HasColumnName("sponsor_status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StudyId)
                    .HasColumnName("study_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UploadDate)
                    .HasColumnName("upload_date")
                    .HasColumnType("date");

                entity.Property(e => e.UploadedBy)
                    .HasColumnName("uploaded_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Uri)
                    .HasColumnName("uri")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TblEmailGroups>(entity =>
            {
                entity.ToTable("tbl_email_groups");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblEmailGrpMdtls>(entity =>
            {
                entity.HasKey(e => new { e.GrpId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_email_grp_mdtls");

                entity.Property(e => e.GrpId)
                    .HasColumnName("grp_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblEmailGrpMembers>(entity =>
            {
                entity.HasKey(e => new { e.GrpId, e.MemberId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_email_grp_members");

                entity.Property(e => e.GrpId)
                    .HasColumnName("grp_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MemberType)
                    .HasColumnName("member_type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblEmailText>(entity =>
            {
                entity.ToTable("tbl_email_text");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumTimes)
                    .HasColumnName("num_times")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Txt)
                    .HasColumnName("txt")
                    .HasColumnType("text");

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblFeedback>(entity =>
            {
                entity.HasKey(e => new { e.EcrfNo, e.Seq })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_feedback");

                entity.Property(e => e.EcrfNo)
                    .HasColumnName("ecrf_no")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Datim)
                    .HasColumnName("datim")
                    .HasColumnType("date");

                entity.Property(e => e.Feedback)
                    .HasColumnName("feedback")
                    .HasColumnType("text");

                entity.Property(e => e.NegativeComments)
                    .HasColumnName("negative_comments")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.SendToNurse)
                    .HasColumnName("send_to_nurse")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<TblFiles>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_files");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContentType)
                    .HasColumnName("content_type")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Displayname)
                    .HasColumnName("displayname")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Extension)
                    .HasColumnName("extension")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.FileData)
                    .HasColumnName("file_data")
                    .HasColumnType("blob");

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Filesize)
                    .HasColumnName("filesize")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UploadDate)
                    .HasColumnName("upload_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblFilters>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PageId, e.Fieldname })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_filters");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PageId)
                    .HasColumnName("page_id")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Fieldname)
                    .HasColumnName("fieldname")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Fieldtype)
                    .HasColumnName("fieldtype")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Fieldvalue)
                    .HasColumnName("fieldvalue")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblGrandchild>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.ChildId, e.Id })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_grandchild");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.ChildId)
                    .HasColumnName("child_id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblGreatgrandchild>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.ChildId, e.GrandparentId, e.Id })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_greatgrandchild");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.ChildId)
                    .HasColumnName("child_id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.GrandparentId)
                    .HasColumnName("grandparent_id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblImages>(entity =>
            {
                entity.ToTable("tbl_images");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageName)
                    .HasColumnName("image_name")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.ImageSize)
                    .HasColumnName("image_size")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SystemPath)
                    .HasColumnName("system_path")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.WebPath)
                    .HasColumnName("web_path")
                    .HasColumnType("varchar(250)");
            });

            modelBuilder.Entity<TblInstImages>(entity =>
            {
                entity.HasKey(e => new { e.InstId, e.ImageId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_inst_images");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageId)
                    .HasColumnName("image_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblInstitutiondetails>(entity =>
            {
                entity.ToTable("tbl_institutiondetails");

                entity.HasIndex(e => e.ActivityStatusId)
                    .HasName("institutiondetails_I8");

                entity.HasIndex(e => e.City)
                    .HasName("institutiondetails_I2");

                entity.HasIndex(e => e.County)
                    .HasName("institutiondetails_I3");

                entity.HasIndex(e => e.CtryId)
                    .HasName("institutiondetails_I4");

                entity.HasIndex(e => e.Postcode)
                    .HasName("institutiondetails_I1");

                entity.HasIndex(e => e.RecieveEmail)
                    .HasName("institutiondetails_I9");

                entity.HasIndex(e => e.SendEmail)
                    .HasName("institutiondetails_I10");

                entity.HasIndex(e => e.Url)
                    .HasName("institutiondetails_I6");

                entity.HasIndex(e => new { e.City, e.County, e.CtryId })
                    .HasName("institutiondetails_I5");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ActivityStatusId)
                    .HasColumnName("activity_status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdrNotes)
                    .HasColumnName("adr_notes")
                    .HasColumnType("text");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CtryId)
                    .HasColumnName("ctry_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.GcpPeriod)
                    .HasColumnName("gcp_period")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstRef)
                    .HasColumnName("inst_ref")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Institution)
                    .HasColumnName("institution")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.RecieveEmail)
                    .HasColumnName("recieve_email")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.SendEmail)
                    .HasColumnName("send_email")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Spare01)
                    .HasColumnName("spare01")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare01lbl)
                    .HasColumnName("spare01lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare02)
                    .HasColumnName("spare02")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare02lbl)
                    .HasColumnName("spare02lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare03)
                    .HasColumnName("spare03")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare03lbl)
                    .HasColumnName("spare03lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Street1)
                    .HasColumnName("street1")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Street2)
                    .HasColumnName("street2")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TelNo)
                    .HasColumnName("tel_no")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblInstpeople>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.InstId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_instpeople");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstRoleId)
                    .HasColumnName("inst_role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.Prime)
                    .HasColumnName("prime")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Spare01)
                    .HasColumnName("spare01")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare01lbl)
                    .HasColumnName("spare01lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare02)
                    .HasColumnName("spare02")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare02lbl)
                    .HasColumnName("spare02lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare03)
                    .HasColumnName("spare03")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare03lbl)
                    .HasColumnName("spare03lbl")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblJobtitle>(entity =>
            {
                entity.ToTable("tbl_jobtitle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblKeydocs>(entity =>
            {
                entity.ToTable("tbl_keydocs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblLocalStatus>(entity =>
            {
                entity.ToTable("tbl_local_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblMessages>(entity =>
            {
                entity.ToTable("tbl_messages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TblParent>(entity =>
            {
                entity.ToTable("tbl_parent");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Colour)
                    .HasColumnName("colour")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.EcrfNo)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_patient");

                entity.Property(e => e.EcrfNo)
                    .HasColumnName("ecrf_no")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.NumTimesLogged)
                    .HasColumnName("num_times_logged")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nurse)
                    .HasColumnName("nurse")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NurseEmail)
                    .HasColumnName("nurse_email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblPersondetails>(entity =>
            {
                entity.ToTable("tbl_persondetails");

                entity.HasIndex(e => e.Active)
                    .HasName("persondetails_I7");

                entity.HasIndex(e => e.Email)
                    .HasName("persondetails_I1");

                entity.HasIndex(e => e.FamilyName)
                    .HasName("persondetails_I3");

                entity.HasIndex(e => e.GivenName)
                    .HasName("persondetails_I10");

                entity.HasIndex(e => e.NumTimes)
                    .HasName("persondetails_I8");

                entity.HasIndex(e => e.PreferredName)
                    .HasName("persondetails_I5");

                entity.HasIndex(e => e.PreviousName)
                    .HasName("persondetails_I4");

                entity.HasIndex(e => e.PrivId)
                    .HasName("persondetails_I9");

                entity.HasIndex(e => e.RecieveEmail)
                    .HasName("persondetails_I13");

                entity.HasIndex(e => e.SecretaryName)
                    .HasName("persondetails_I2");

                entity.HasIndex(e => e.SendEmail)
                    .HasName("persondetails_I14");

                entity.HasIndex(e => new { e.GivenName, e.FamilyName })
                    .HasName("persondetails_I11");

                entity.HasIndex(e => new { e.Username, e.Pwd })
                    .HasName("persondetails_I6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.CvReceivedId)
                    .HasColumnName("cv_received_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.FamilyName)
                    .HasColumnName("family_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GcpDate)
                    .HasColumnName("gcp_date")
                    .HasColumnType("date");

                entity.Property(e => e.GcpReceivedId)
                    .HasColumnName("gcp_received_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GcpStartDate)
                    .HasColumnName("gcp_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GivenName)
                    .HasColumnName("given_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MainJobTitleId)
                    .HasColumnName("main_job_title_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.NumTimes)
                    .HasColumnName("num_times")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreferredName)
                    .HasColumnName("preferred_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PreviousName)
                    .HasColumnName("previous_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PrivId)
                    .HasColumnName("priv_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecieveEmail)
                    .HasColumnName("recieve_email")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.SecondaryJobTitleId)
                    .HasColumnName("secondary_job_title_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SecretaryEmail)
                    .HasColumnName("secretary_email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SecretaryName)
                    .HasColumnName("secretary_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SecretaryTel)
                    .HasColumnName("secretary_tel")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.SendEmail)
                    .HasColumnName("send_email")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ShortCvDate)
                    .HasColumnName("short_cv_date")
                    .HasColumnType("date");

                entity.Property(e => e.Spare01)
                    .HasColumnName("spare01")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare01lbl)
                    .HasColumnName("spare01lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare02)
                    .HasColumnName("spare02")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare02lbl)
                    .HasColumnName("spare02lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare03)
                    .HasColumnName("spare03")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare03lbl)
                    .HasColumnName("spare03lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TelNo)
                    .HasColumnName("tel_no")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<TblPrivileges>(entity =>
            {
                entity.ToTable("tbl_privileges");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblQuestionGrp>(entity =>
            {
                entity.ToTable("tbl_question_grp");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblQuestionPool>(entity =>
            {
                entity.ToTable("tbl_question_pool");

                entity.HasIndex(e => e.Active)
                    .HasName("question_pool_I4");

                entity.HasIndex(e => e.GrpId)
                    .HasName("question_pool_I2");

                entity.HasIndex(e => e.TypId)
                    .HasName("question_pool_I1");

                entity.HasIndex(e => new { e.TypId, e.GrpId })
                    .HasName("question_pool_I3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Datim)
                    .HasColumnName("datim")
                    .HasColumnType("date");

                entity.Property(e => e.GrpId)
                    .HasColumnName("grp_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasColumnType("text");

                entity.Property(e => e.TypId)
                    .HasColumnName("typ_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblQuestionType>(entity =>
            {
                entity.ToTable("tbl_question_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblQuestionaire>(entity =>
            {
                entity.ToTable("tbl_questionaire");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Commplete)
                    .HasColumnName("commplete")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Datim)
                    .HasColumnName("datim")
                    .HasColumnType("date");

                entity.Property(e => e.EcrfNo)
                    .IsRequired()
                    .HasColumnName("ecrf_no")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.StudyId)
                    .HasColumnName("study_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TemplateId)
                    .HasColumnName("template_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblQuestionaireAnswers>(entity =>
            {
                entity.HasKey(e => new { e.QuestionaireId, e.QuestionId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_questionaire_answers");

                entity.Property(e => e.QuestionaireId)
                    .HasColumnName("questionaire_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TblReceivedstatus>(entity =>
            {
                entity.ToTable("tbl_receivedstatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblResponsestatus>(entity =>
            {
                entity.ToTable("tbl_responsestatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblSpareData>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.Seq, e.RecordId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_spare_data");

                entity.HasIndex(e => e.RecordId)
                    .HasName("spare_I1");

                entity.HasIndex(e => new { e.RecordId, e.Fieldvalue })
                    .HasName("spare_I2");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RecordId)
                    .HasColumnName("record_id")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Fieldvalue)
                    .HasColumnName("fieldvalue")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblSpareDefn>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.Seq })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_spare_defn");

                entity.HasIndex(e => e.Active)
                    .HasName("spare_defn_I2");

                entity.HasIndex(e => new { e.TableName, e.Active })
                    .HasName("spare_defn_I3");

                entity.HasIndex(e => new { e.TableName, e.Seq, e.Active })
                    .HasName("spare_defn_I1");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Fieldlabel)
                    .HasColumnName("fieldlabel")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Fieldtype)
                    .HasColumnName("fieldtype")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Purpose)
                    .HasColumnName("purpose")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TblSpareEnum>(entity =>
            {
                entity.ToTable("tbl_spare_enum");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblSpareTypes>(entity =>
            {
                entity.ToTable("tbl_spare_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<TblSponsorStatus>(entity =>
            {
                entity.ToTable("tbl_sponsor_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblStudyinst>(entity =>
            {
                entity.HasKey(e => new { e.StudyId, e.InstId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_studyinst");

                entity.HasIndex(e => e.CloseoutVisitDate)
                    .HasName("studyinst_I6");

                entity.HasIndex(e => e.DateApproached)
                    .HasName("studyinst_I1");

                entity.HasIndex(e => e.DateRegReturned)
                    .HasName("studyinst_I2");

                entity.HasIndex(e => e.DateSiv)
                    .HasName("studyinst_I3");

                entity.HasIndex(e => e.FirstAccrualDate)
                    .HasName("studyinst_I4");

                entity.HasIndex(e => e.FirstMonVisitDate)
                    .HasName("studyinst_I5");

                entity.HasIndex(e => e.ResponseStatusId)
                    .HasName("studyinst_I8");

                entity.HasIndex(e => e.SiteClosedDate)
                    .HasName("studyinst_I7");

                entity.Property(e => e.StudyId)
                    .HasColumnName("study_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.CloseoutVisitDate)
                    .HasColumnName("closeout_visit_date")
                    .HasColumnType("date");

                entity.Property(e => e.DateApproached)
                    .HasColumnName("date_approached")
                    .HasColumnType("date");

                entity.Property(e => e.DateRegReturned)
                    .HasColumnName("date_reg_returned")
                    .HasColumnType("date");

                entity.Property(e => e.DateSiv)
                    .HasColumnName("date_siv")
                    .HasColumnType("date");

                entity.Property(e => e.FirstAccrualDate)
                    .HasColumnName("first_accrual_date")
                    .HasColumnType("date");

                entity.Property(e => e.FirstMonVisitDate)
                    .HasColumnName("first_mon_visit_date")
                    .HasColumnType("date");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.ResponseStatusId)
                    .HasColumnName("response_status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SiteClosedDate)
                    .HasColumnName("site_closed_date")
                    .HasColumnType("date");

                entity.Property(e => e.Spare01)
                    .HasColumnName("spare01")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare01lbl)
                    .HasColumnName("spare01lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare02)
                    .HasColumnName("spare02")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare02lbl)
                    .HasColumnName("spare02lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare03)
                    .HasColumnName("spare03")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare03lbl)
                    .HasColumnName("spare03lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.StudyStatusId)
                    .HasColumnName("study_status_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblStudypeople>(entity =>
            {
                entity.HasKey(e => new { e.StudyId, e.InstId, e.PersonId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_studypeople");

                entity.HasIndex(e => e.Main)
                    .HasName("studypeople_I1");

                entity.HasIndex(e => e.StudyRoleId)
                    .HasName("studypeople_I2");

                entity.HasIndex(e => new { e.StudyId, e.PersonId, e.Active })
                    .HasName("studypeople_I3");

                entity.Property(e => e.StudyId)
                    .HasColumnName("study_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.InviteDate)
                    .HasColumnName("invite_date")
                    .HasColumnType("date");

                entity.Property(e => e.Main)
                    .HasColumnName("main")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.ResponseDate)
                    .HasColumnName("response_date")
                    .HasColumnType("date");

                entity.Property(e => e.ResponseStatusId)
                    .HasColumnName("response_status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Spare01)
                    .HasColumnName("spare01")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare01lbl)
                    .HasColumnName("spare01lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare02)
                    .HasColumnName("spare02")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare02lbl)
                    .HasColumnName("spare02lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare03)
                    .HasColumnName("spare03")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare03lbl)
                    .HasColumnName("spare03lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.StudyRoleId)
                    .HasColumnName("study_role_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblStudyrole>(entity =>
            {
                entity.ToTable("tbl_studyrole");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblStudystatus>(entity =>
            {
                entity.ToTable("tbl_studystatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<TblStudytypes>(entity =>
            {
                entity.ToTable("tbl_studytypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TblSysupdate>(entity =>
            {
                entity.HasKey(e => new { e.Sys, e.Seq })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_sysupdate");

                entity.Property(e => e.Sys)
                    .HasColumnName("sys")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateUpd)
                    .HasColumnName("date_upd")
                    .HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Vers)
                    .HasColumnName("vers")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TblTempDetail>(entity =>
            {
                entity.HasKey(e => new { e.TemplateId, e.QuestionId })
                    .HasName("PRIMARY");

                entity.ToTable("tbl_temp_detail");

                entity.Property(e => e.TemplateId)
                    .HasColumnName("template_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblTemplate>(entity =>
            {
                entity.ToTable("tbl_template");

                entity.HasIndex(e => e.StudyId)
                    .HasName("template_I1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Datim)
                    .HasColumnName("datim")
                    .HasColumnType("date");

                entity.Property(e => e.Nam)
                    .HasColumnName("nam")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StudyId)
                    .HasColumnName("study_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblText>(entity =>
            {
                entity.ToTable("tbl_text");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TblTitle>(entity =>
            {
                entity.ToTable("tbl_title");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<TblTrash>(entity =>
            {
                entity.ToTable("tbl_trash");

                entity.HasIndex(e => e.DeleteDate)
                    .HasName("trash_I2");

                entity.HasIndex(e => e.DeletedBy)
                    .HasName("trash_I3");

                entity.HasIndex(e => e.DocId)
                    .HasName("trash_I1");

                entity.HasIndex(e => e.InstId)
                    .HasName("trash_I5");

                entity.HasIndex(e => e.StudyId)
                    .HasName("trash_I4");

                entity.HasIndex(e => new { e.StudyId, e.InstId })
                    .HasName("trash_I6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeleteDate)
                    .HasColumnName("delete_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DocId)
                    .HasColumnName("doc_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstId)
                    .HasColumnName("inst_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StudyId)
                    .HasColumnName("study_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TblTrialdetails>(entity =>
            {
                entity.ToTable("tbl_trialdetails");

                entity.HasIndex(e => e.Shortname)
                    .HasName("trialdetails_I1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descr)
                    .HasColumnName("descr")
                    .HasColumnType("text");

                entity.Property(e => e.Funder)
                    .HasColumnName("funder")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.GcpAlertPeriod)
                    .HasColumnName("gcp_alert_period")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Isrctn)
                    .HasColumnName("isrctn")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LogoId)
                    .HasColumnName("logo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MhraRef)
                    .HasColumnName("mhra_ref")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.RecRef)
                    .HasColumnName("rec_ref")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Shortname)
                    .HasColumnName("shortname")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Spare01)
                    .HasColumnName("spare01")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare01lbl)
                    .HasColumnName("spare01lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare02)
                    .HasColumnName("spare02")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare02lbl)
                    .HasColumnName("spare02lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Spare03)
                    .HasColumnName("spare03")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Spare03lbl)
                    .HasColumnName("spare03lbl")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Sponsor)
                    .HasColumnName("sponsor")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TrialRef)
                    .HasColumnName("trial_ref")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.TrialactivitystatusId)
                    .HasColumnName("trialactivitystatus_id")
                    .HasColumnType("int(11)");
            });
        }
    }
}
