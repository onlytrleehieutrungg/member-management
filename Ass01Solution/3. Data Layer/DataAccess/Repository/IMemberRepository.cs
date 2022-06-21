using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public IEnumerable<Member> GetMemebers();
        Member GetMemberById(int memberId);
        void AddMember(Member member);
        void DeleteMember(int memberId);
        void UpdateMember(Member member);
    }
}