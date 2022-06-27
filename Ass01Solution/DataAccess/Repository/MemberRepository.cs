using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetMemebers() => MemberDAO.Instance.GetMemberList();

        public Member GetMemberById(string memberId) => MemberDAO.Instance.GetMemberById(memberId);

        public void AddMember(Member member) => MemberDAO.Instance.AddNew(member);

        public void DeleteMember(string memberId) => MemberDAO.Instance.RemoveMember(memberId);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateNewMember(member);

        public Member Login(string username, string password) => MemberDAO.Instance.Login(username, password);

        public IEnumerable<Member> Search(string id) => MemberDAO.Instance.SearchMember(id);
    }
}