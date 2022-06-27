using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public IEnumerable<Member> GetMemebers();
        Member GetMemberById(string memberId);
        void AddMember(Member member);
        void DeleteMember(string memberId);
        void UpdateMember(Member member);
    }
}