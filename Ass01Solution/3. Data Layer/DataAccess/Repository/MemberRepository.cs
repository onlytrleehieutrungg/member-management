using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetMemebers() => MemberDAO.Instance.GetMembers;

        public Member GetMemberById(int memberId) => MemberDAO.Instance.GetMemberById(memberId);

        public void AddMember(Member member) => MemberDAO.Instance.AddNewMember(member);

        public void DeleteMember(int memberId) => MemberDAO.Instance.RemoveMember(memberId);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateNewMember(member);
    }
}