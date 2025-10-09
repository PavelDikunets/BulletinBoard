using AutoMapper;
using BulletinBoard.Contracts.Announcements.Requests;
using BulletinBoard.Contracts.Announcements.Responses;
using BulletinBoard.Domain.Entities;

namespace BulletinBoard.Infrastructure.ComponentRegistrar.MapProfiles;

/// <summary>
///     Профиль маппера для объявления.
/// </summary>
public class AnnouncementProfile : Profile
{
    public AnnouncementProfile()
    {
        CreateMap<AnnouncementFilterRequest, Announcement>(MemberList.None);
        CreateMap<CreateAnnouncementRequest, Announcement>(MemberList.None);
        CreateMap<UpdateAnnouncementRequest, Announcement>(MemberList.None);

        CreateMap<Announcement, AnnouncementResponse>(MemberList.None);
        CreateMap<Announcement, AnnouncementShortResponse>(MemberList.None);
    }
}