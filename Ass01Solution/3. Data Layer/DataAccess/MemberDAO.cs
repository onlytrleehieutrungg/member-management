using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;

namespace DataAccess
{
    public class MemberDAO
    {
        private static List<Member> MemberList = new List<Member>()
        {
            new Member
            {
                MemberId = "1", MemberName = "Trung", Email = "trungtran2k01", 
                Password = "123123", City = "SG", Country = "QN"
            }
        };

        private MemberDAO()
        {
        }

        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();

        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Member> GetMembers => MemberList;

        public Member GetMemberById(string memberId)
        {
            Member member = MemberList.SingleOrDefault(mem => mem.MemberId.Equals(memberId));
            return member;
        }

        public void AddNewMember(Member member)
        {
            Member mem = GetMemberById(member.MemberId);
            if (mem==null)
            {
                MemberList.Add(mem);
            }
            else
            {
                throw new Exception("Member already exists.");

            }
        }
        public void UpdateNewMember(Member member)
        {
            Member mem = GetMemberById(member.MemberId);
            if (mem!=null)
            {
                var index = MemberList.IndexOf(mem);
                MemberList[index] = mem;
            }
            else
            {
                throw new Exception("Member does not already exists.");

            }
        }

        public void RemoveMember(string memberId)
        {
            Member member = GetMemberById(memberId);
            if (member!=null)
            {
                MemberList.Remove(member);
            }else{
                throw new Exception("Member dose not already exists.");
            }
        }
    }
}