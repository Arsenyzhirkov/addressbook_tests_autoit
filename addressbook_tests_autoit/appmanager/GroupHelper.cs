using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        public void Add(GroupData group)
        {
            OpenGroupsDialogue();
            InitGroupCreation();
            FillgroupName(group);
            CloseGroupsDialogue();
        }
        public void Remove(int index)
        {
            OpenGroupsDialogue();
            SelectGroup(index);
            InitGroupRemoval();
            RemoveGroup();

            CloseGroupsDialogue();
        }

        private void InitGroupCreation()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.179a6ef_r7_ad13");
        }

        private void FillgroupName(GroupData group)
        {
            aux.Send(group.Name);
            aux.Send("{ENTER}");
        }

 
        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.179a6ef_r7_ad14");
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.179a6ef_r7_ad112");
            aux.WinWait(GROUPWINTITLE);
        }
        public int GetCountGroups()
        {
            return int.Parse(aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.179a6ef_r7_ad11",
        "GetItemCount", "#0", ""));
        }

        public void RemoveGroup()
        {
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.179a6ef_r7_ad13");
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.179a6ef_r7_ad14");
        }

        public void InitGroupRemoval()
        {

            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.179a6ef_r7_ad11");
            aux.WinWait(DELETEGROUPWINTITLE);
        }

        public void SelectGroup(int index)
        {
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.179a6ef_r7_ad11",
                                "Select", "Contact groups|#" + index, "");
        }
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();

            OpenGroupsDialogue();

            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.179a6ef_r7_ad11",
                "GetItemCount", "#0", "");


            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.179a6ef_r7_ad11",
                "GetText", "#0|#" + i, "");

                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }
        internal void AddGroup()
        {
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.179a6ef_r7_ad11",
                                               "GetItemCount", "#0", "");
            if (int.Parse(count) == 1)
            {
                Add(new GroupData()
                {
                    Name = "TESTTEST"
                });
            }
            CloseGroupsDialogue();
        }
    }
}