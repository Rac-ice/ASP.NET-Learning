USE [master]
GO
/****** Object:  Database [NewsDb]    Script Date: 08/13/2023 20:54:07 ******/
CREATE DATABASE [NewsDb] ON  PRIMARY 
( NAME = N'NewsDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\NewsDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NewsDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\NewsDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NewsDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewsDb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [NewsDb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [NewsDb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [NewsDb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [NewsDb] SET ARITHABORT OFF
GO
ALTER DATABASE [NewsDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [NewsDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [NewsDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [NewsDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [NewsDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [NewsDb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [NewsDb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [NewsDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [NewsDb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [NewsDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [NewsDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [NewsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [NewsDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [NewsDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [NewsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [NewsDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [NewsDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [NewsDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [NewsDb] SET  READ_WRITE
GO
ALTER DATABASE [NewsDb] SET RECOVERY FULL
GO
ALTER DATABASE [NewsDb] SET  MULTI_USER
GO
ALTER DATABASE [NewsDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [NewsDb] SET DB_CHAINING OFF
GO
USE [NewsDb]
GO
/****** Object:  Table [dbo].[T_News]    Script Date: 08/13/2023 20:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Msg] [nvarchar](max) NOT NULL,
	[SubDateTime] [datetime] NOT NULL,
	[Author] [nvarchar](32) NOT NULL,
	[ImagePath] [nvarchar](128) NULL,
 CONSTRAINT [PK_T_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_News] ON
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (1, N'“去中国化”的后果来了！', N'最近几周，欧美一大批海上风电开发计划被取消，原因是难以承受涡轮机、电缆和其他风电设备的建设成本和产品价格大幅上涨，甚至一些关键设备的质量也被打上问号。据彭博社7日报道，德国的西门子能源在最新季度财报中表示，风机发电组的质量问题导致了22亿欧元的损失，这使得公司今年总亏损达到了45亿欧元左右。有分析认为，欧美清洁能源雄心很大，但自身风电供应链已经存在瓶颈。', CAST(0x0000B05C00004650 AS DateTime), N'环球时报', NULL)
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (2, N'王毅谈当前南海地区局势', N'中共中央政治局委员、外交部长王毅在访问新加坡和马来西亚期间同两国政要就当前南海局势交换看法，阐明中方立场。8月5日，菲律宾派出两艘执行补给任务的补给船和海警船前往仁爱礁，中国海警船进行了理性克制的执法劝阻。随后，菲方召见我驻菲大使，并抗议中国海警使用水炮，违反《联合国海洋法公约》和“南海仲裁案”结果。与此同时，万里之外的美国也借机横插一脚。美国国务院迅速发表声明，公开为菲律宾“站台”，重申《美菲共同防御条约》的承诺，指责中国对仁爱礁的主张“不合法”。（一）', CAST(0x0000B05C00949710 AS DateTime), N'郑海琦 ', NULL)
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (3, N'【新思想引领新征程】科学防沙治沙 筑牢美丽中国绿色屏障', N'习近平总书记强调，加强荒漠化综合防治，深入推进“三北”等重点生态工程建设，事关我国生态安全、事关强国建设、事关中华民族永续发展，是一项功在当代、利在千秋的崇高事业。党的十八大以来，我国多措并举推进荒漠化治理，防沙治沙取得巨大成就，进一步筑牢美丽中国绿色屏障。从高空俯瞰，世界最大的生态工程，也是防沙治沙的重点标志性工程——“三北”工程经过不懈努力，在横跨我国北方400多万平方公里的土地上筑起了一道绿色生态屏障。从“沙进人退”到“绿进沙退”，我国的绿色版图不断扩大，荒漠化和沙化土地持续双缩减。第六次全国荒漠化、沙化调查结果显示，我国首次实现所有调查省份荒漠化和沙化土地“双逆转”。习近平总书记高度重视防沙治沙工作，党的十八大以来，他先后到内蒙古赤峰市马鞍山林场、河北塞罕坝机械林场等“三北”工程重点林场实地考察防沙治沙情况，对防沙治沙工作提出了明确要求。今年6月，习近平总书记主持召开加强荒漠化综合防治和推进“三北”等重点生态工程建设座谈会并发表重要讲话，再次对我国荒漠化防治工作作出战略部署。十年来，我国累计完成防沙治沙任务2033万公顷，53%的可治理沙化土地得到治理，荒漠化、沙化土地面积分别比十年前净减少500万公顷、433万公顷，沙区植被平均覆盖度上升了2.6个百分点。八大沙漠、四大沙地的土壤风蚀总量较2000年下降约40%。十年来，全国累计完成造林10.2亿亩、森林抚育12.4亿亩，全国森林覆盖率提高到24.02%，人工林保存面积达13.14亿亩，居全球首位。近十年，全球新增森林面积的四分之一来自中国，我国成为森林资源增长最快最多的国家。在多年与风沙的抗争中，我国摸索总结出了100多项具有中国特色的荒漠化防治技术。目前，我国已建立荒漠化防治的理论与技术体系，为我国的生态工程建设提供了重要科技支撑。经过不懈努力，我国提前实现了联合国提出的，到2030年实现土地退化零增长的目标。2021—2030年是“三北”工程六期工程建设期，也是巩固拓展防沙治沙成果的关键期。目前，围绕打好黄河“几字弯”攻坚战，科尔沁、浑善达克两大沙地歼灭战，河西走廊—塔克拉玛干沙漠边缘阻击战等三大标志性战役，自然资源部、国家林草局重点起草了《关于加强荒漠化综合防治和推进“三北”等重点生态工程建设的意见》，国家发展改革委牵头编制完成“三北”工程总体规划修编，并明确六期规划编制思路。', CAST(0x0000B05C007D54C4 AS DateTime), N'新闻联播', NULL)
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (6, N'落实落细防汛抗洪救灾措施 加快恢复正常生产生活秩序', N'连日来，东北、华北等地以及各有关部门认真贯彻落实习近平总书记关于防汛抗洪救灾工作的重要指示精神，落实落细各项措施，持续推进灾后重建、受灾群众生活保障工作，加快恢复正常生产生活秩序。今天（8月11日），国家防总、应急管理部等部门持续进行防汛调度会商。目前，台风“卡努”已经给东北地区带来风雨影响，要警惕降雨落区和前期洪涝区域的叠加风险，开展隐患排查，严防次生灾害。水利部松辽委强化会商研判，预报台风移动路径及降雨落区变化，逐流域、逐河流、逐区域迭代更新防御方案，突出抓好防御重点。截至今早8时，黑龙江省有乌苏里江、松花江、绥芬河等10条河流超警戒水位。受台风“卡努”影响，东宁市出现强降雨。在老黑山村，巡查人员今天凌晨发现河水迅速上涨，民警联合当地镇、村干部挨家挨户通知村民转移。目前，东宁市位于沿河两岸、低洼地带的村屯已将人员转移到安全区域，全市共设置6个临时安置点。受降雨影响，绥芬河市部分地区出现积水，当地采取疏通河道、转移群众等措施，党员干部下沉防汛风险区域巡查值守。今天下午4时，松花江绥滨段水位超警戒水位1.08米，为确保安全度汛，当地对松花江堤坝路段实行了交通管制。吉林榆树市此前发生洪涝灾害的8个乡镇陆续展开清淤排涝，紧临拉林河的延和乡是受灾最重的区域，民房平均过水深度近1米，清淤工作紧张进行。目前，吉林省本轮降雨主要集中在东部，珲春市出现中到大雨，当地所有旅游景点暂停营业，市政部门对高处的广告牌、树杈进行了拉网式巡查和固定。辽宁省多地出现6—8级大风，目前，全省有超过2.5万艘渔船在港避风，共撤离海上作业人员9000多人。自然资源部在对辽宁、吉林、黑龙江3省启动地质灾害防御Ⅲ级响应的同时，又紧急增派3组专家工作组赶赴一线，会同地方加强会商研判和高风险区地质灾害防御指导。今天，河北召开防汛救灾暨灾后重建新闻发布会。此次洪涝灾害发生以来，河北先后出动抢险队伍95.9万人次，全省累计转移群众175.74万人。今年9月1日前，保证每一名受灾学生都能按时开学返校；今年入冬前，确保受灾群众能够回家或搬入新居、安全温暖过冬；2024年汛期前，全面完成水毁防洪工程重建工作。河北涿州高新技术产业开发区基本用水、用电陆续恢复，企业尽快复工复产。民生行业也加快复工，多家商场陆续恢复营业，开始调拨货品，满足市民需求。为尽快解决因暴雨灾害而产生的涉水汽车保险理赔，涿州还在多个小区设置理赔定损点，简化理赔流程和手续，开展快速定损工作。北京门头沟城区包括育园小学新建工程等13项重点工程全面复工，与此同时，灾后防疫有序展开。北京市卫健委已累计派出17支防疫小分队深入重点区域，加强生活饮用水安全监测和督导检查，统筹做好药品、设备、防护和消杀物资保障。今天，北京市气象台发布暴雨蓝色预警，预计11日—12日，北京房山、门头沟、昌平等地局地将出现小时雨量超过30毫米的短时强降水，相关地区和部门应注意防范强降水诱发的泥石流、滑坡、崩塌等次生灾害。天津行洪工作仍在继续。截至今天6时，大清河上游新盖房下泄流量较前一日下降明显，大清河静海台头段水位已由此前最高6米降至5.77米。此外，永定河固安下泄流量持续呈减小趋势。天津市武清区正陆续开展过水村落整体防疫消杀、抽水排水和垃圾清运等灾后恢复工作，加快恢复生产生活秩序。今天，财政部、应急管理部再次紧急预拨14.6亿元中央自然灾害救灾资金，支持京津冀及黑龙江、吉林5省（市）防汛救灾工作，重点用于受灾群众救助，保障好受灾群众基本生活，迅速启动倒损住房恢复重建等事项。加上此前已预拨资金，入汛以来，中央财政已下达各项防汛救灾资金77.38亿元。', CAST(0x0000B05C008DF3D8 AS DateTime), N'新闻联播', NULL)
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (7, N'【党旗在基层一线高高飘扬】洪水中的逆行者', N'7月31日，北京门头沟区遭遇大暴雨。在防汛抢险中，龙泉镇副镇长刘捷为了疏散群众，不幸卷入激流，献出了宝贵生命。这几天，门头沟区龙泉镇中门寺村正在进行清淤工作。从7月29日开始，门头沟连续遭遇强暴雨，龙泉镇副镇长刘捷负责中门寺村等6个村子和社区的防汛工作。连续两天，他与同事一起，封闭危险路段、清理泄洪道，深夜冒雨赶到地势低洼的三家店村，挨个打电话通知居民，清理挪走了200多辆汽车。当晚，同事发现刘捷的身体有异样，让他赶紧吃下了速效救心丸。31日上午，雨势不断增大，中门寺村区域出现险情，300多名群众亟待转移，一夜未眠的刘捷又驾车赶往现场。半路上，刘捷发现村民任桂仙还没有回家，就摇下车窗对她大声呼喊。驱车赶往村里的路上，水越来越深，刘捷发现有群众准备去挪车，他使劲呼喊，让他们放弃挪车回到了高地。这时，山洪突然倾泻而下，刘捷来不及撤离，中门寺村村委委员李巧玲站在高地上眼睁睁看着他的汽车被卷进了湍急的洪水。2002年，刘捷成为了一名共产党员。即使父亲和妻子相继身患癌症，身为家里的顶梁柱，刘捷也没有因此对工作懈怠。龙泉镇东南街社区9号楼的厨房下水道多年不通，54户居民苦不堪言，刘捷奔波了一年，筹措资金、调解矛盾，监督设计施工，终于让居民用上了畅通的下水管线。在家中，记者看到了他多年来的工作笔记，在一本本笔记本的扉页上都写着“服务、服务、再服务”。', CAST(0x0000B05C009E8608 AS DateTime), N'新闻联播', NULL)
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (8, N'【学思想 强党性 重实践 建新功】筑牢思想根基 为党育才为党献策', N'中央党校（国家行政学院）在主题教育中紧紧围绕为党育才、为党献策的党校初心，以习近平新时代中国特色社会主义思想凝心铸魂，通过组织开展大学习、大备课、大调研、大研究活动，扎实提高党的创新理论的教学科研水平，为党校（行政学院）事业高质量发展注入强大动力。主题教育开展以来，中央党校（国家行政学院）在“凝心铸魂、筑牢根本”上下功夫、抓实效，举办系列主题教育读书班，充分发挥自身优势，由14位理论功底深厚的专题授课教师“磨”出优质系列好课，全方位系统化地呈现了习近平新时代中国特色社会主义思想的精髓要义。筑牢真信仰，夯实基本功。中央党校（国家行政学院）组织开展了由校（院）委会成员带头的全校集体大备课，并赴福建省、浙江省等多个省份，开展39项专题调研，提高教师讲全、讲准、讲深、讲透习近平新时代中国特色社会主义思想的真本领，并发挥业务指导作用，对全国省、市、县三级6000余名党校（行政学院）校长（院长）、常务副校长（副院长）进行了全覆盖培训。中央党校（国家行政学院）还以这次主题教育为契机，着力在党的创新理论研究阐释等方面发力，形成了一批立得住、叫得响、有分量的研究成果，多篇研究成果已转化为课堂教学内容。', CAST(0x0000B05C008E2F9C AS DateTime), N'新闻联播 ', NULL)
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (9, N'国内联播快讯', N'世界最大清洁能源走廊日发电量超10亿度记者今天（8月11日）从三峡集团获悉，世界最大清洁能源走廊长江干流乌东德、白鹤滩等6座梯级电站百台机组同步运行，单日发电量连续三天超10亿度，一天的发电量相当于105万人一年用电需求，有效缓解了华东、华南、华中等地区的用电压力。南京海关签发RCEP签证出口货值超186亿元今年1—7月，南京海关共签发RCEP原产地证书5.94万份，签证出口货值186.76亿元，同比分别增长38.64%和10.49%，位列全国首位。浙江市场经营主体总量突破1000万户8月10日，浙江省市场经营主体总量突破1000万户。目前，平均每个工作日新登记市场经营主体6400户左右。为培育壮大市场经营主体，浙江持续深化商事制度改革，全方位加强服务赋能。国产支线客机ARJ21飞机完成高海拔地区演示飞行记者今天（8月11日）从中国商飞了解到，国产支线客机ARJ21在云南完成了为期1个月的高海拔演示飞行，执飞了云南全部15个运输机场，总飞行时间157.55小时。ARJ21是我国自主研制的支线客机，此次演示飞行为后续拓展支线航空市场打下坚实基础。成都大运村今天正式闭村今天（8月11日），成都大运村正式闭村，最后80多名代表团成员离村，启程回国。成都海关开辟了4条绿色通道，设置大运会离境物资专用查验区，采取“海关+安检”一次查验模式，方便快捷办理出境手续。“国家应急科普库”共建项目启动应急管理部与中央广播电视总台今天（8月11日）签署战略合作框架协议暨“国家应急科普库”共建项目启动。双方将进一步深化联动机制，在舆论引导、信息共享、应急科普等领域开展务实合作，共同推进完善国家应急管理体系和能力现代化。电视剧《冰雪尖刀连》今晚开播电视剧《冰雪尖刀连》今晚（8月11日）起在央视综合频道黄金档开播。该剧讲述了抗美援朝作战期间，中国人民志愿军战士爬冰卧雪、浴血奋战、保家卫国的故事。该剧以长津湖战役为背景，塑造了英雄群像，弘扬伟大抗美援朝精神。《高端访谈》专访阿塞拜疆总统阿利耶夫中央广播电视总台央视新闻频道《高端访谈》栏目今晚（8月11日）将播出对阿塞拜疆总统阿利耶夫的独家专访。阿利耶夫表示，阿塞拜疆支持并积极参与共建“一带一路”，期待阿中两国合作百尺竿头更进一步。节目还将在央视新闻、央视频、央视网等新媒体平台同步上线。', CAST(0x0000B05C009EBD1C AS DateTime), N'新闻联播 ', NULL)
SET IDENTITY_INSERT [dbo].[T_News] OFF
/****** Object:  Table [dbo].[T_UserInfo]    Script Date: 08/13/2023 20:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](32) NOT NULL,
	[UserPwd] [nvarchar](32) NOT NULL,
	[UserMail] [nvarchar](64) NULL,
	[RegTime] [datetime] NOT NULL,
 CONSTRAINT [PK_T_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_UserInfo] ON
INSERT [dbo].[T_UserInfo] ([Id], [UserName], [UserPwd], [UserMail], [RegTime]) VALUES (1, N'test', N'123', N'123@123.com', CAST(0x0000B05C01785EAF AS DateTime))
SET IDENTITY_INSERT [dbo].[T_UserInfo] OFF
/****** Object:  Table [dbo].[T_NewsComments]    Script Date: 08/13/2023 20:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_NewsComments](
	[Id] [int] NOT NULL,
	[NewId] [int] NOT NULL,
	[Msg] [nvarchar](128) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_T_NewsComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_T_NewsComments_T_NewsComments]    Script Date: 08/13/2023 20:54:10 ******/
ALTER TABLE [dbo].[T_NewsComments]  WITH CHECK ADD  CONSTRAINT [FK_T_NewsComments_T_NewsComments] FOREIGN KEY([NewId])
REFERENCES [dbo].[T_News] ([Id])
GO
ALTER TABLE [dbo].[T_NewsComments] CHECK CONSTRAINT [FK_T_NewsComments_T_NewsComments]
GO
