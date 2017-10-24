/*
Navicat MySQL Data Transfer

Source Server         : kjds
Source Server Version : 50621
Source Host           : 120.24.159.138:3306
Source Database       : kjds

Target Server Type    : MYSQL
Target Server Version : 50621
File Encoding         : 65001

Date: 2017-10-24 19:04:15
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `accounttype`
-- ----------------------------
DROP TABLE IF EXISTS `accounttype`;
CREATE TABLE `accounttype` (
  `ID` varchar(64) NOT NULL,
  `TypeName` varchar(64) DEFAULT NULL COMMENT '账号类型名称',
  `IsShow` tinyint(1) DEFAULT NULL COMMENT '前台是否展示',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='账号类型';

-- ----------------------------
-- Records of accounttype
-- ----------------------------
INSERT INTO `accounttype` VALUES ('00971df6-4316-4b90-85b8-3681c4d3a867', '111', '0', null, '2017-05-31 16:20:25', null, null, null, null, null);
INSERT INTO `accounttype` VALUES ('13e7c3bb-99b2-40b5-9c30-15b946929418', '11', '1', null, '2017-05-31 16:07:55', null, null, '1', null, null);
INSERT INTO `accounttype` VALUES ('48288c42-46fb-440f-a3b9-eff05d0424eb', '222', '1', null, '2017-06-01 16:36:48', null, null, null, null, null);
INSERT INTO `accounttype` VALUES ('5d70e427-9a1b-4f3c-b6dd-f49fd86fe111', '112', '1', null, '2017-05-31 16:17:24', null, null, '1', null, null);

-- ----------------------------
-- Table structure for `area`
-- ----------------------------
DROP TABLE IF EXISTS `area`;
CREATE TABLE `area` (
  `ID` varchar(64) NOT NULL,
  `AreaName` varchar(64) DEFAULT NULL COMMENT '地区名',
  `PID` varchar(64) DEFAULT NULL COMMENT '上级地区ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='地区';

-- ----------------------------
-- Records of area
-- ----------------------------
INSERT INTO `area` VALUES ('1', '湖南', '0', null, null, null, null, null, null, null);
INSERT INTO `area` VALUES ('2', '长沙', '1', null, null, null, null, null, null, null);
INSERT INTO `area` VALUES ('3', '株洲', '1', null, null, null, null, null, null, null);
INSERT INTO `area` VALUES ('4', '湖北', '0', null, null, null, null, null, null, null);
INSERT INTO `area` VALUES ('5', '武汉', '4', null, null, null, null, null, null, null);
INSERT INTO `area` VALUES ('6', '黄冈', '4', null, null, null, null, null, null, null);
INSERT INTO `area` VALUES ('7', '孝感', '4', null, null, null, null, null, null, null);
INSERT INTO `area` VALUES ('8', '北京', '0', null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `authorize`
-- ----------------------------
DROP TABLE IF EXISTS `authorize`;
CREATE TABLE `authorize` (
  `ID` varchar(64) NOT NULL,
  `RoleID` varchar(64) DEFAULT NULL COMMENT '角色ID',
  `AccountTypeID` varchar(64) DEFAULT NULL COMMENT '类型ID 区分是哪种账号类型权限',
  `AuthorizeName` varchar(64) DEFAULT NULL COMMENT '权限名称',
  `AuthorizeType` varchar(64) DEFAULT NULL COMMENT '权限类型（1 菜单 2 按钮）',
  `EnCode` varchar(64) DEFAULT NULL COMMENT '编码',
  `PID` varchar(64) DEFAULT NULL COMMENT '父级权限',
  `Icon` varchar(64) DEFAULT NULL COMMENT '图标',
  `UrlAddress` varchar(512) DEFAULT NULL COMMENT '连接地址',
  `Target` varchar(64) DEFAULT NULL COMMENT '目标',
  `IsMenu` tinyint(1) DEFAULT NULL COMMENT '是否为菜单 true 菜单',
  `IsExpand` tinyint(1) DEFAULT NULL COMMENT '是否展开 true 展开',
  `IsPublic` tinyint(1) DEFAULT NULL COMMENT '是否公开',
  `AllowEdit` tinyint(1) DEFAULT NULL COMMENT '是否允许编辑',
  `SortCode` int(11) DEFAULT NULL COMMENT '排序',
  `JsEvent` varchar(64) DEFAULT NULL COMMENT 'JS事件',
  `Split` tinyint(1) DEFAULT NULL COMMENT '分割线',
  `ReMark` varchar(512) DEFAULT NULL COMMENT '备注',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='权限表';

-- ----------------------------
-- Records of authorize
-- ----------------------------
INSERT INTO `authorize` VALUES ('0143dac8-e3b4-43e2-bc5c-932b44a7978e', null, null, '查看菜单', '2', 'NF-Details', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-01-16 14:15:54', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('0c05d42f-8b86-4949-9495-e57e5941b5ed', null, null, '修改用户', '2', 'NF-edit', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-02-08 15:21:45', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('1238a352-26d4-44a5-8660-6539f3189f49', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '培训管理', '1', null, 'aee22449-0428-4ccb-877a-d726f3ffcfdf', null, '/TrainInfo/Index', '1', '0', '0', '0', '0', '5', null, null, null, null, '2017-01-16 15:38:57', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('175cec55-9d61-4df1-8054-1715a44a7c7f', null, null, '重新开课', '2', 'NF-revisepassword', '343a4cad-fd4e-4b21-8215-f116f3773ec5', null, null, null, null, null, '0', '0', '6', null, '0', null, null, '2017-01-16 16:05:02', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('17b3a804-3d4c-44d4-9a81-f46229541e62', null, null, '密码重置', '2', 'NF-revisepassword', 'aedc9263-2dcf-4adf-a5ac-0fef5f517b67', null, null, null, null, null, '0', '0', '5', null, '0', null, null, '2017-02-07 17:46:08', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('18ab9ba8-e81d-4f63-ad24-17a67490d28c', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '用户管理', '1', null, 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', null, '/SysManage/User/Index', '1', '0', '0', '0', '0', '5', null, null, null, null, '2017-01-16 14:33:18', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('1ac7cd1e-1bf4-4427-bc78-2b4a830c7208', null, null, '修改培训信息', '2', 'NF-edit', '1238a352-26d4-44a5-8660-6539f3189f49', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-01-16 16:06:20', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('21b45422-e317-461d-a17f-f77299083efe', null, null, '查看角色', '2', 'NF-Details', '34be011c-ce25-479a-8630-3d50b9e1a0f5', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-01-16 14:55:44', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('24bc7ace-56c5-49b2-a2ab-eb019fd16c60', null, null, '修改权限', '2', 'NF-edit', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', null, '/SysManage/Authorize/Form', null, null, null, '0', '0', '2', 'btn_edit()', '0', null, null, '2017-01-06 17:53:48', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('2605ca30-0caf-40e9-a882-c309ce1673ba', null, null, '新增权限', '2', 'NF-add', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', null, '/SysManage/AuthorizeButton/Form', null, null, null, '0', '0', '1', null, '0', '123', null, '2017-01-06 15:23:09', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('30def16f-d07b-4513-a472-747ef0cf391d', null, null, '审批用户', '2', 'NF-approve', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '8', null, '1', null, null, '2017-02-08 16:12:13', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('30ef22a6-928a-4ac6-a679-8e1d6ed29b31', null, null, '查看账号类型', '2', 'NF-Details', '420f221c-6ed5-4b6f-b87e-b4bca2752510', null, 'SysManage/AccountType/Details', null, null, null, '0', '0', '4', 'btn_details()/', '0', null, null, '2017-01-10 09:52:57', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('332493df-9224-41cc-825f-3a92103cd66b', null, null, '11', '2', '001', '837843f1-2304-4361-97e5-5145a9931625', '12', '2', null, null, null, '1', '0', '1', '11', '1', '1234', null, '2017-06-01 11:05:52', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('3356bc63-c5fd-4c75-a2fc-a7ab33c9bfdd', null, '00971df6-4316-4b90-85b8-3681c4d3a867', '123', '1', null, '9de9a74d-8845-431c-a189-24dae9511f27', null, '111', '0', '0', '0', '1', '0', '1', null, null, null, null, '2017-06-01 10:36:22', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('33fab425-1513-4eeb-9288-a52d0a8afa34', null, null, '密码重置', '2', 'NF-revisepassword', '18ab9ba8-e81d-4f63-ad24-17a67490d28c', null, null, null, null, null, '0', '0', '5', null, '0', null, null, '2017-01-16 15:14:46', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('343a4cad-fd4e-4b21-8215-f116f3773ec5', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '课程管理', '1', null, 'aee22449-0428-4ccb-877a-d726f3ffcfdf', null, '/Course/Index', '1', '0', '0', '0', '0', '2', null, null, null, null, '2017-01-16 15:35:17', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('34be011c-ce25-479a-8630-3d50b9e1a0f5', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '角色管理', '1', null, 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', null, '/SysManage/Role/Index', '1', '1', '0', '0', '0', '4', null, null, null, null, '2017-01-16 14:21:05', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('41dd47e3-c146-4f05-bf49-4ce4d1f6ca3f', null, null, '查看机构', '2', 'NF-Details', '7362541b-2c8e-45a5-aa0d-ddad160fead1', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-01-16 14:43:35', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('420f221c-6ed5-4b6f-b87e-b4bca2752510', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '账号类型管理', '1', null, 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', null, '/SysManage/AccountType/Index', '1', '1', '0', '1', '0', '1', null, null, '1234', null, '2017-01-05 15:45:33', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('47ffad9a-92d8-4e5a-8c42-4d4f9700c582', null, null, '修改机构', '2', 'NF-edit', '7362541b-2c8e-45a5-aa0d-ddad160fead1', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-01-16 14:42:49', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('49469d17-7d29-4331-ba32-8118ad21491e', null, null, '创建培训活动', '2', 'NF-add', '1238a352-26d4-44a5-8660-6539f3189f49', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-01-16 16:06:01', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('4b2ac8a8-326b-4400-80b1-fde2608f0eaf', null, null, '修改课程', '2', 'NF-edit', '343a4cad-fd4e-4b21-8215-f116f3773ec5', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-01-16 16:03:40', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('4d420626-d0af-4578-8d88-164c70a1357d', null, null, '查看用户', '2', 'NF-Details', 'aedc9263-2dcf-4adf-a5ac-0fef5f517b67', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-02-07 17:45:37', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('4f4954e9-3663-435e-8b04-4b1b5ee3f84b', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '权限管理', '1', null, 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', null, '/SysManage/Authorize/Index', '1', '1', '0', '0', '0', '2', null, null, '456', null, '2017-01-05 16:57:37', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('4f5fb813-eb35-4ad3-a360-56d7fbd3e90b', null, null, '删除大纲', '2', 'NF-delete', 'd433f459-84da-45c2-aade-772e5128d3d1', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-01-16 16:01:14', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('5086f847-5f31-40b1-aa1d-d3309139ca6a', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '学校系统管理', '1', null, '0', 'fa fa-university', null, '0', '0', '0', '0', '0', '4', null, null, null, null, '2017-01-17 10:19:40', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('515332e6-dd95-420b-9c58-bd9196af11f4', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '用户管理', '1', null, '5086f847-5f31-40b1-aa1d-d3309139ca6a', null, '/SchoolManage/User/Index', '1', '0', '0', '0', '0', '1', null, null, null, null, '2017-01-17 10:21:02', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('550747d7-e51b-4b29-89ab-573b7da5881e', null, null, '查看用户', '2', 'NF-Details', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-02-08 15:22:29', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('59c42ae5-1950-4e46-a311-8cc10fefe16c', null, null, '删除课程', '2', 'NF-delete', '343a4cad-fd4e-4b21-8215-f116f3773ec5', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-01-16 16:03:56', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('5bdd72bc-f0c1-4a10-bb25-dd7093e100e6', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '项目服务', '1', null, '0', 'fa fa-tasks', null, '0', '0', '0', '0', '0', '5', null, null, null, null, '2017-01-17 16:29:55', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('5e0da7b0-f61b-429e-9d2a-eb4b6ad68001', null, null, '新建用户', '2', 'NF-add', 'aedc9263-2dcf-4adf-a5ac-0fef5f517b67', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-02-07 17:43:53', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('60675e10-6989-48d7-9ace-54212f1605b3', null, null, '删除用户', '2', 'NF-delete', 'aedc9263-2dcf-4adf-a5ac-0fef5f517b67', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-02-07 17:44:48', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('629232fa-9615-47ce-98ca-4e3c5d358fe7', null, null, '查看用户', '2', 'NF-Details', '18ab9ba8-e81d-4f63-ad24-17a67490d28c', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-01-16 15:15:04', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('6b371db0-8be4-4fd7-9044-7bea7d07f47e', null, null, '新建用户', '2', 'NF-add', '18ab9ba8-e81d-4f63-ad24-17a67490d28c', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-01-16 15:13:23', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('6d8b8a2c-9e57-422e-ae1b-63580a4dc8db', null, null, '删除机构', '2', 'NF-delete', '7362541b-2c8e-45a5-aa0d-ddad160fead1', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-01-16 14:43:11', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('7362541b-2c8e-45a5-aa0d-ddad160fead1', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '机构管理', '1', null, 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', null, '/SysManage/Organize/Index', '1', '1', '0', '0', '0', '3', null, null, null, null, '2017-01-16 14:29:30', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('7719b1d1-d684-41ec-be88-34b063a72378', null, null, '禁用', '2', 'NF-disabled', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '6', null, '0', null, null, '2017-02-08 15:18:14', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('77e0c04b-5f74-4724-9410-b51b0eb36f11', null, null, '删除角色', '2', 'NF-delete', '34be011c-ce25-479a-8630-3d50b9e1a0f5', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-01-16 14:55:24', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('809d8f00-4505-48f4-8196-dc9c98da7df6', null, null, '上传活动总结', '2', 'NF-Summary', '1238a352-26d4-44a5-8660-6539f3189f49', null, null, null, null, null, '0', '0', '5', null, '0', null, null, '2017-01-16 16:07:50', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('837843f1-2304-4361-97e5-5145a9931625', null, '00971df6-4316-4b90-85b8-3681c4d3a867', '333', '1', null, '0', null, '123', '1', '0', '0', '1', '0', '3', null, null, null, null, '2017-06-01 10:38:08', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('8c452931-d5ed-47ed-9dd4-1179d400ebee', null, null, '密码重置', '2', 'NF-revisepassword', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '5', null, '0', null, null, '2017-02-08 15:22:56', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('8f5e5397-c72f-4c82-8b5a-f1f74ae58993', null, null, '删除账号类型', '2', 'NF-delete', '420f221c-6ed5-4b6f-b87e-b4bca2752510', null, '/SysManage/AccountType/DeleteForm', null, null, null, '0', '0', '3', 'btn_delete()', '0', null, null, '2017-01-10 09:51:54', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('957df709-29d1-4a2d-8f5f-090004c8475a', null, null, '删除用户', '2', 'NF-delete', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-02-08 15:22:05', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('9ac92b44-11d2-4ef0-aca5-ec0cdefd1574', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '试题库管理', '1', null, 'aee22449-0428-4ccb-877a-d726f3ffcfdf', null, '/QuestionsManage/QuestionsDb/Index', '1', '1', '0', '0', '1', '3', null, null, null, null, '2017-01-16 15:38:04', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('9b1e604e-ba48-499f-9610-dfb239ebdf7c', null, null, '新增账号类型', '2', 'NF-add', '420f221c-6ed5-4b6f-b87e-b4bca2752510', null, '/SysManage/AccountType/Form', null, null, null, '0', '0', '1', 'btn_add()', '0', null, null, '2017-01-10 09:47:39', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('9de9a74d-8845-431c-a189-24dae9511f27', null, '00971df6-4316-4b90-85b8-3681c4d3a867', '1111', '1', null, '0', '111111', '11111', '1', '1', '0', '0', '1', '1111', null, null, '1111', null, '2017-05-31 16:27:43', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('9fb08436-030f-4c97-a978-35208aab2cda', null, null, '新建角色', '2', 'NF-add', '34be011c-ce25-479a-8630-3d50b9e1a0f5', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-01-16 14:54:33', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('a040e0dc-1e06-40e4-8972-d07d68079720', null, null, '新增账号类型', '2', 'AddAccountType', '', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-01-06 17:33:36', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('a6e2359e-59e0-45fc-95b8-b33762839902', null, null, '修改账号类型', '2', 'NF-edit', '420f221c-6ed5-4b6f-b87e-b4bca2752510', null, '/SysManage/AccountType/Form', null, null, null, '0', '0', '2', 'btn_edit()', '0', null, null, '2017-01-10 09:48:37', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('ab537161-700e-44e4-bab3-b1756feb7f66', null, null, '查看课程', '2', 'NF-Details', '343a4cad-fd4e-4b21-8215-f116f3773ec5', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-01-16 16:04:18', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('aedc9263-2dcf-4adf-a5ac-0fef5f517b67', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '用户管理', '1', null, 'd15c482f-c570-4269-be62-2e65a26df98e', null, '/EnterpriseManage/User/Index', '1', '1', '1', '1', '1', '1', null, null, null, null, '2017-02-07 17:40:04', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('aee22449-0428-4ccb-877a-d726f3ffcfdf', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '资源管理', '1', null, '0', 'fa fa-hdd-o', null, '0', '0', '0', '0', '0', '3', null, null, null, null, '2017-01-16 15:32:11', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('b2eb97ea-fba2-4dcc-a61a-02d7af2065d1', null, null, '修改用户', '2', 'NF-edit', 'aedc9263-2dcf-4adf-a5ac-0fef5f517b67', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-02-07 17:44:17', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('b7ed4022-8871-4e36-a0de-08a3aafa5dee', null, null, '新建用户', '2', 'NF-add', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-02-08 15:18:46', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('b97c8459-8563-476a-8982-2c3f3f073475', null, null, '修改角色', '2', 'NF-edit', '34be011c-ce25-479a-8630-3d50b9e1a0f5', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-01-16 14:54:56', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('c111d6c7-713f-4b5b-b6fb-2516edbcd997', null, null, '启用', '2', 'NF-enabled', '515332e6-dd95-420b-9c58-bd9196af11f4', null, null, null, null, null, '0', '0', '7', null, '0', null, null, '2017-02-08 15:23:38', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('c2026ac6-ccf5-4d0b-92f4-19f6ed234b94', null, null, '按钮管理', '2', 'NF-modulebutton', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', null, null, null, null, null, '0', '0', '5', null, '1', null, null, '2017-01-16 14:16:26', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('d0bba16f-8f63-41d7-9190-e030c4b85e96', null, null, '修改用户', '2', 'NF-edit', '18ab9ba8-e81d-4f63-ad24-17a67490d28c', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-01-16 15:13:43', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('d1209e7f-9c15-414e-a77e-57f44965d3a0', null, null, '修改大纲', '2', 'NF-edit', 'd433f459-84da-45c2-aade-772e5128d3d1', null, null, null, null, null, '0', '0', '2', null, '0', null, null, '2017-01-16 16:00:56', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('d15c482f-c570-4269-be62-2e65a26df98e', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '企业系统管理', '1', null, '0', 'fa fa-cube', null, '1', '1', '1', '1', '1', '6', null, null, null, null, '2017-02-07 17:38:52', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('d433f459-84da-45c2-aade-772e5128d3d1', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '课程大纲管理', '1', null, 'aee22449-0428-4ccb-877a-d726f3ffcfdf', null, '/CourseChapter/Index', '1', '0', '0', '0', '0', '1', null, null, null, null, '2017-01-16 15:34:21', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('d4d0349f-5b9d-4b49-a94a-56a841b62531', null, null, '上传课件', '2', 'NF-addsouce', '343a4cad-fd4e-4b21-8215-f116f3773ec5', null, null, null, null, null, '0', '0', '5', null, '0', null, null, '2017-01-16 16:04:42', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('db27e833-1899-4310-8dce-0aa5daaeb7e1', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '项目管理', '1', null, '5bdd72bc-f0c1-4a10-bb25-dd7093e100e6', null, '/Employ/Index', '1', '0', '0', '0', '0', '1', null, null, null, null, '2017-01-17 16:30:20', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('dc515acc-d493-4b33-bd46-bff6c6d41ec1', null, null, '新建课程大纲', '2', 'NF-add', 'd433f459-84da-45c2-aade-772e5128d3d1', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-01-16 16:00:37', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('dd8b4e66-2fe6-4dd1-bab1-2cda22f20dee', null, null, '删除培训活动', '2', 'NF-delete', '1238a352-26d4-44a5-8660-6539f3189f49', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-01-16 16:06:59', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('df202a67-e340-433b-b3bc-4ed3aa8fd1d5', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '系统管理', '1', null, '0', 'fa fa-home', null, '0', '1', '1', '1', '1', '2', null, null, null, null, '2017-01-05 15:34:36', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('df8b48e2-cb2e-4bf3-89a0-f50ee0abb2e3', null, null, '55', '2', '001', '837843f1-2304-4361-97e5-5145a9931625', '11', '12', null, null, null, '1', '0', '1', '12', '0', '124', null, '2017-06-01 10:52:37', null, null, '1', null, null);
INSERT INTO `authorize` VALUES ('e60bfeb3-61f8-41e0-9f17-7e3d9240394e', null, null, '查看培训信息', '2', 'NF-Details', '1238a352-26d4-44a5-8660-6539f3189f49', null, null, null, null, null, '0', '0', '4', null, '0', null, null, '2017-01-16 16:07:20', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('e60c98cd-bc6a-4af6-9f17-791f01c973d2', null, null, '删除菜单', '2', 'NF-delete', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-01-16 14:13:39', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('e8bd2f6b-cca9-49fb-9658-6c8be3c3afb9', null, null, '删除用户', '2', 'NF-delete', '18ab9ba8-e81d-4f63-ad24-17a67490d28c', null, null, null, null, null, '0', '0', '3', null, '0', null, null, '2017-01-16 15:14:22', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('ea4de15e-eaa4-492c-8504-61349c45f05d', null, null, '新建机构', '2', 'NF-add', '7362541b-2c8e-45a5-aa0d-ddad160fead1', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-01-16 14:42:28', null, null, null, null, null);
INSERT INTO `authorize` VALUES ('f4e93a02-2efd-48f0-9ea9-7a5ee21fea4d', null, null, '创建课程', '2', 'NF-add', '343a4cad-fd4e-4b21-8215-f116f3773ec5', null, null, null, null, null, '0', '0', '1', null, '0', null, null, '2017-01-16 16:03:24', null, null, null, null, null);

-- ----------------------------
-- Table structure for `banner`
-- ----------------------------
DROP TABLE IF EXISTS `banner`;
CREATE TABLE `banner` (
  `ID` varchar(64) NOT NULL,
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='广告条';

-- ----------------------------
-- Records of banner
-- ----------------------------

-- ----------------------------
-- Table structure for `chaptercontent`
-- ----------------------------
DROP TABLE IF EXISTS `chaptercontent`;
CREATE TABLE `chaptercontent` (
  `ID` varchar(64) NOT NULL,
  `CourserID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `ChapterID` varchar(64) DEFAULT NULL COMMENT '章节ID',
  `FileID` varchar(64) DEFAULT NULL COMMENT '文件ID',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '内容分类ID',
  `TestQuestionNum` int(11) DEFAULT NULL COMMENT '试题数量',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='章节内容';

-- ----------------------------
-- Records of chaptercontent
-- ----------------------------
INSERT INTO `chaptercontent` VALUES ('23f3315f-dfa0-4df2-bf92-0c9530a4c17f', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', 'ec6e277b-5af5-4b7f-9271-358fd009d15b', '/Courseware/20170116111257343员工考勤表12月.xlsx', '图片', null, null, '2017-01-16 11:13:49', null, null, null, null, null);
INSERT INTO `chaptercontent` VALUES ('27cd529d-5794-4d60-827c-53baef685bc4', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', 'ec6e277b-5af5-4b7f-9271-358fd009d15b', '/Courseware/20170116111245595Nodata.png', '图片', null, null, '2017-01-16 11:13:44', null, null, null, null, null);
INSERT INTO `chaptercontent` VALUES ('426df14a-e2e4-4632-9ad4-45abdf672a43', 'ec60c7f5-9204-48fe-9f16-81b39095f10a', null, '&nbsp;', '图片', null, null, '2017-05-31 11:26:44', null, null, null, null, null);
INSERT INTO `chaptercontent` VALUES ('c2c458cd-336b-4316-8eb8-b160141e3cd2', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '121wrwer', '/Courseware/20170106171607524校徽.jpg', '图片', null, null, '2017-01-06 17:16:29', null, null, null, null, null);

-- ----------------------------
-- Table structure for `chaptercontenttype`
-- ----------------------------
DROP TABLE IF EXISTS `chaptercontenttype`;
CREATE TABLE `chaptercontenttype` (
  `ID` varchar(64) NOT NULL,
  `TypeName` varchar(64) DEFAULT NULL COMMENT '内容分类名称（视频，文档，PPT）',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='章节内容类型';

-- ----------------------------
-- Records of chaptercontenttype
-- ----------------------------

-- ----------------------------
-- Table structure for `chapterquestionselect`
-- ----------------------------
DROP TABLE IF EXISTS `chapterquestionselect`;
CREATE TABLE `chapterquestionselect` (
  `ID` varchar(64) NOT NULL,
  `CourserID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `ChapterID` varchar(64) DEFAULT NULL COMMENT '培训资源指定人ID',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '题目类型',
  `QName` varchar(64) DEFAULT NULL COMMENT '题目题干',
  `Answer` varchar(4) DEFAULT NULL COMMENT '答案',
  `SelectA` varchar(64) DEFAULT NULL,
  `SelectB` varchar(64) DEFAULT NULL,
  `SelectC` varchar(64) DEFAULT NULL,
  `SelectD` varchar(64) DEFAULT NULL,
  `Score` int(11) DEFAULT NULL COMMENT '分数',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='课程章节试题--选择题';

-- ----------------------------
-- Records of chapterquestionselect
-- ----------------------------
INSERT INTO `chapterquestionselect` VALUES ('ab2cdaa3-3d76-419a-ad27-40c578bd38e6', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '705c2cbe-d540-44ea-beaa-789127cefa5d', null, '我的第一题', 'B', '你选不选A', '我选BC', '那我选C', 'ABC都不选，我选D', '2', null, '2017-03-09 10:40:46', null, '2017-03-09 17:29:16', null, null, null);
INSERT INTO `chapterquestionselect` VALUES ('e4338d01-bc58-4200-85fe-0141bd731e4f', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '705c2cbe-d540-44ea-beaa-789127cefa5d', null, '电子商务', 'A', 'A', 'B', 'C', 'D', '0', null, '2017-05-31 14:40:23', null, '2017-05-31 14:40:40', '1', null, null);

-- ----------------------------
-- Table structure for `chapterquestiontr`
-- ----------------------------
DROP TABLE IF EXISTS `chapterquestiontr`;
CREATE TABLE `chapterquestiontr` (
  `ID` varchar(64) NOT NULL,
  `CourserID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `ChapterID` varchar(64) DEFAULT NULL COMMENT '培训资源指定人ID',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '题目类型',
  `QName` varchar(256) DEFAULT NULL COMMENT '题目题干',
  `Answer` tinyint(1) DEFAULT NULL,
  `Score` int(11) DEFAULT NULL COMMENT '分数',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='课程章节试题--判断题';

-- ----------------------------
-- Records of chapterquestiontr
-- ----------------------------
INSERT INTO `chapterquestiontr` VALUES ('9e4b1c48-ba40-46a9-a031-ca616e442a7d', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '80e88778-c628-44b3-9a4c-bf12ef4a56ae', null, '100块都不给', '0', '2', null, '2017-03-09 10:46:20', null, null, null, null, null);
INSERT INTO `chapterquestiontr` VALUES ('a1ef79b5-f190-46da-90f6-b65d53a95026', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '705c2cbe-d540-44ea-beaa-789127cefa5d', null, '电子商务', '1', '2', null, '2017-03-09 10:42:13', null, '2017-05-31 14:39:04', null, null, null);
INSERT INTO `chapterquestiontr` VALUES ('f57d546b-e4f0-48d9-91d8-6490649ec484', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '705c2cbe-d540-44ea-beaa-789127cefa5d', null, '11111111111111', '0', '0', null, '2017-06-01 14:44:05', null, '2017-06-01 14:44:18', '1', null, null);

-- ----------------------------
-- Table structure for `cooperateorg`
-- ----------------------------
DROP TABLE IF EXISTS `cooperateorg`;
CREATE TABLE `cooperateorg` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '机构ID',
  `CoopUserID` varchar(64) DEFAULT NULL COMMENT '合作机构ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='机构合作信息';

-- ----------------------------
-- Records of cooperateorg
-- ----------------------------

-- ----------------------------
-- Table structure for `cooperateorgrecord`
-- ----------------------------
DROP TABLE IF EXISTS `cooperateorgrecord`;
CREATE TABLE `cooperateorgrecord` (
  `ID` varchar(64) NOT NULL,
  `OrgUserID` varchar(64) DEFAULT NULL COMMENT '机构ID',
  `CoopUserID` varchar(64) DEFAULT NULL COMMENT '合作机构用户ID',
  `FileName` varchar(64) DEFAULT NULL COMMENT '文件名',
  `FileID` varchar(64) DEFAULT NULL COMMENT '文件ID',
  `FileTypeId` varchar(64) DEFAULT NULL COMMENT '文件类型ID',
  `UploadUserID` varchar(64) DEFAULT NULL COMMENT '上传用户ID',
  `UploadTime` varchar(64) DEFAULT NULL COMMENT '上传时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='合作机构相关档案';

-- ----------------------------
-- Records of cooperateorgrecord
-- ----------------------------

-- ----------------------------
-- Table structure for `course`
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course` (
  `ID` varchar(64) NOT NULL,
  `LevelID` varchar(64) DEFAULT NULL COMMENT '课程级别ID',
  `PhotoID` varchar(64) DEFAULT NULL COMMENT '图片ID',
  `CourseName` varchar(64) DEFAULT NULL COMMENT '课程大纲名称',
  `SetTime` datetime DEFAULT NULL COMMENT '制定时间',
  `StatusCode` tinyint(4) DEFAULT NULL COMMENT '状态',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `SerialNum` int(11) DEFAULT NULL COMMENT '期数（1，2，3，4）',
  `PreCourse` varchar(64) DEFAULT NULL COMMENT '上一期课程ID 若无则为0',
  `IsTest` tinyint(1) DEFAULT NULL,
  `IsShow` tinyint(1) DEFAULT NULL,
  `Desc` text,
  `CreateCourseUserID` varchar(64) DEFAULT NULL COMMENT '课程创始人',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='课程';

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES ('291838d0-712f-4d09-bf1a-1c7746cc4cf5', '0', '/Image/20170105150616611gallery-2.jpg', '电子商务理论', '2017-01-05 15:27:09', '0', '2017-01-06 00:00:00', '2017-01-07 00:00:00', '1', '8ca1d4c3-4ab5-4cc2-9234-2e431a0eba86', '1', '0', '电子商务理论是一门专门讲述电商的基础知识以及发展史的课程', '5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '2017-01-05 15:27:09', null, null, '0', null, null);
INSERT INTO `course` VALUES ('35819176-84d0-407d-bbe3-e1a0e1853bf0', '0', null, '234', null, '2', '2017-05-23 00:00:00', '2017-05-31 00:00:00', '0', null, '0', '0', null, null, null, '2017-05-31 10:45:58', null, null, '1', null, null);
INSERT INTO `course` VALUES ('378660b2-67dc-4f24-8579-3118b52c05ed', '0', '/Image/20170110105147906user-7.jpg', '市场营销学', '2017-01-10 10:51:52', '0', '2017-01-11 00:00:00', '2017-01-19 00:00:00', '0', null, '1', '0', null, '5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '2017-01-10 10:51:52', null, null, '0', null, null);
INSERT INTO `course` VALUES ('8ca1d4c3-4ab5-4cc2-9234-2e431a0eba86', '0', '/Image/20170105150616611gallery-2.jpg', '电子商务理论', '2017-01-05 15:06:19', '2', '2017-01-04 00:00:00', '2017-01-05 00:00:00', '0', null, '1', '1', null, '5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '2017-01-05 15:06:19', null, null, '0', null, null);
INSERT INTO `course` VALUES ('96ed46d8-eda7-4af6-8a4f-018eb8b569c8', '1', null, '生物', null, '1', '2017-04-18 00:00:00', '2017-06-22 00:00:00', '0', null, '0', '0', null, null, null, '2017-05-27 14:42:55', null, null, '0', null, null);
INSERT INTO `course` VALUES ('9769c3eb-17cf-45a4-b3f2-982875ae0ce4', '0', '/Image/20170110112312239bg-1.jpg', '经济学原理', '2017-01-10 11:23:16', '2', '2017-01-04 00:00:00', '2017-01-07 00:00:00', '0', null, '1', '0', null, '5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '2017-01-10 11:23:16', null, null, '0', null, null);
INSERT INTO `course` VALUES ('b641bd41-b073-46b6-8854-13d6dca9aba2', '0', '/Image/20170331104239840Nodata.png', 'fff', '2017-03-31 10:44:33', '2', '2017-04-05 00:00:00', '2017-04-05 00:00:00', '0', null, '0', '0', null, '5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '2017-03-31 10:44:33', null, null, '1', null, null);
INSERT INTO `course` VALUES ('b7673424-c235-48ff-8382-a3505d53a524', '0', null, '单点', '2017-02-15 09:52:46', '1', '2017-02-15 00:00:00', '2017-02-25 00:00:00', '0', null, '1', '0', null, '5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '2017-02-15 09:52:46', null, null, '1', null, null);
INSERT INTO `course` VALUES ('cc813824-6868-4e3b-ab6f-1d5eb6cfd409', '1', null, '生物', null, '1', '2017-04-18 00:00:00', '2017-06-22 00:00:00', '0', null, '0', '0', null, null, null, '2017-05-27 14:41:41', null, null, '0', null, null);
INSERT INTO `course` VALUES ('cca6528c-9ac6-4da4-a718-294926b0f9e9', '0', null, '11', null, '1', '2017-05-31 00:00:00', '2017-06-30 00:00:00', '0', null, '1', '0', null, null, null, '2017-05-31 11:02:19', null, null, '1', null, null);
INSERT INTO `course` VALUES ('d981ab78-94ab-40ae-8496-ae35316b6e2c', '1', null, '公告', '2017-02-15 09:55:40', '2', null, null, '0', null, '1', '0', null, '5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '2017-02-15 09:55:40', null, null, '0', null, null);
INSERT INTO `course` VALUES ('ec60c7f5-9204-48fe-9f16-81b39095f10a', '1', null, '生物', null, '2', '2017-05-01 00:00:00', '2017-05-24 00:00:00', '0', null, '0', '0', null, null, null, '2017-05-27 14:44:16', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `coursechapter`
-- ----------------------------
DROP TABLE IF EXISTS `coursechapter`;
CREATE TABLE `coursechapter` (
  `ID` varchar(64) NOT NULL,
  `CourserID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '培训资源指定人ID',
  `ChapterName` varchar(64) DEFAULT NULL COMMENT '章节名称',
  `SetTime` datetime DEFAULT NULL COMMENT '制定时间',
  `SequenceID` int(11) DEFAULT NULL COMMENT '顺序值',
  `PID` varchar(64) DEFAULT NULL COMMENT '父级ID （默认0）',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='课程章节';

-- ----------------------------
-- Records of coursechapter
-- ----------------------------
INSERT INTO `coursechapter` VALUES ('07c14a7f-df24-441b-8748-544b5a4c3409', 'ec60c7f5-9204-48fe-9f16-81b39095f10a', '1', '生物', '2017-06-12 09:35:47', '1', '0', null, '2017-06-12 09:35:47', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('1acabbf5-fb79-4de0-9220-5613b676574a', 'ec60c7f5-9204-48fe-9f16-81b39095f10a', '1', '第2章 1', '2017-05-31 09:24:55', '2', 'aa0aaa89-0cbb-4dbd-9d2d-7674330db83a', null, '2017-05-31 09:24:54', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('1c6b71ef-9a2d-4567-81f0-d87e339ee72d', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '李丽', '电子商务理论', '2017-03-07 15:40:05', '1', '0', null, '2017-03-07 15:40:05', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('3308a322-39fa-4de3-a55e-6ff049432314', '378660b2-67dc-4f24-8579-3118b52c05ed', '的', '第1章 什么是市场', '2017-03-07 16:08:02', '1', '5c4e0d7f-9890-461f-abbe-d604458e18bc', null, '2017-03-07 16:08:02', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('4244836f-4d21-45bf-b727-368537aa61e6', 'd981ab78-94ab-40ae-8496-ae35316b6e2c', '1', '公告', '2017-06-12 10:13:03', '1', '0', null, '2017-06-12 10:13:03', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('5bf92e6e-3635-444d-9203-b62b14959b42', '378660b2-67dc-4f24-8579-3118b52c05ed', '李丽', '第1节 基本概念', '2017-03-07 15:45:23', '1', '5c204b3e-70d4-4e9c-88dc-153ef4ce1ff4', null, '2017-03-07 15:45:23', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('5c204b3e-70d4-4e9c-88dc-153ef4ce1ff4', '378660b2-67dc-4f24-8579-3118b52c05ed', '李丽', '第1章 营销概念', '2017-03-07 15:44:33', '1', 'ea6f80d9-02b2-420c-8204-bcb40abb1c03', null, '2017-03-07 15:44:22', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('5c4e0d7f-9890-461f-abbe-d604458e18bc', '378660b2-67dc-4f24-8579-3118b52c05ed', '的', '市场营销学', '2017-03-07 16:08:02', '1', '0', null, '2017-03-07 16:08:02', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('5d874cd1-955a-41e8-b005-4ce69576f3d8', 'ec60c7f5-9204-48fe-9f16-81b39095f10a', '1', '第1章 1', '2017-05-31 09:25:09', '1', 'aa0aaa89-0cbb-4dbd-9d2d-7674330db83a', null, '2017-05-31 09:25:09', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('67b9702f-5355-4ef2-85b9-c0ae914dc41f', 'ec60c7f5-9204-48fe-9f16-81b39095f10a', '1', '第1章 1', '2017-06-12 09:35:47', '1', '07c14a7f-df24-441b-8748-544b5a4c3409', null, '2017-06-12 09:35:47', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('705c2cbe-d540-44ea-beaa-789127cefa5d', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '李丽', '第1章 序言', '2017-03-07 15:41:12', '1', '1c6b71ef-9a2d-4567-81f0-d87e339ee72d', null, '2017-03-07 15:40:29', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('7145949f-140e-4977-ad83-96cfd4142e6f', '378660b2-67dc-4f24-8579-3118b52c05ed', 'Lily', '第1章 什么是市场', '2017-05-31 10:41:01', '1', '5c4e0d7f-9890-461f-abbe-d604458e18bc', null, '2017-05-31 10:41:01', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('7807feba-1b34-4207-bcb2-37c6499f341d', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '李丽', '第1节 电子商务', '2017-03-07 15:43:21', '1', '80e88778-c628-44b3-9a4c-bf12ef4a56ae', null, '2017-03-07 15:43:21', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('7b1a07b6-4891-453a-aa60-4602578de2d1', 'd981ab78-94ab-40ae-8496-ae35316b6e2c', '1', '第1章 1', '2017-06-12 10:13:03', '1', '4244836f-4d21-45bf-b727-368537aa61e6', null, '2017-06-12 10:13:03', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('80e88778-c628-44b3-9a4c-bf12ef4a56ae', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '李丽', '第2章 什么是电子商务', '2017-03-07 15:42:39', '2', '1c6b71ef-9a2d-4567-81f0-d87e339ee72d', null, '2017-03-07 15:42:39', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('aa0aaa89-0cbb-4dbd-9d2d-7674330db83a', 'ec60c7f5-9204-48fe-9f16-81b39095f10a', '1', '生物', '2017-05-31 09:24:54', '1', '0', null, '2017-05-31 09:24:54', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('dd172483-6ccb-4474-bedc-c9afe1b803ac', '378660b2-67dc-4f24-8579-3118b52c05ed', '地点', '第3章 嘻嘻嘻', '2017-03-07 15:54:14', '3', 'ea6f80d9-02b2-420c-8204-bcb40abb1c03', null, '2017-03-07 15:54:13', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('ea6f80d9-02b2-420c-8204-bcb40abb1c03', '378660b2-67dc-4f24-8579-3118b52c05ed', '李丽', '市场营销学', '2017-03-07 15:44:02', '1', '0', null, '2017-03-07 15:44:02', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('f12879f6-c3ed-47f7-b4ce-262bf3c9f6f2', '378660b2-67dc-4f24-8579-3118b52c05ed', '是的', '市场营销学', '2017-03-07 16:05:20', '1', '0', null, '2017-03-07 16:05:11', null, null, '1', null, null);
INSERT INTO `coursechapter` VALUES ('f301609d-69b6-4c6a-be68-7da34f2ee2c1', '378660b2-67dc-4f24-8579-3118b52c05ed', '地点', '第1章 父', '2017-03-07 15:58:30', '1', 'ea6f80d9-02b2-420c-8204-bcb40abb1c03', null, '2017-03-07 15:56:45', null, null, '0', null, null);
INSERT INTO `coursechapter` VALUES ('fab09b6d-b3d9-42e1-98a1-3973535cd1a4', '378660b2-67dc-4f24-8579-3118b52c05ed', '的', '第2章 对对对', '2017-03-07 15:55:29', '2', 'ea6f80d9-02b2-420c-8204-bcb40abb1c03', null, '2017-03-07 15:54:52', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `courselevel`
-- ----------------------------
DROP TABLE IF EXISTS `courselevel`;
CREATE TABLE `courselevel` (
  `ID` varchar(64) NOT NULL,
  `LevelName` varchar(64) DEFAULT NULL COMMENT '课程级别名称',
  `SetTime` datetime DEFAULT NULL COMMENT '制定时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='课程级别';

-- ----------------------------
-- Records of courselevel
-- ----------------------------

-- ----------------------------
-- Table structure for `courseorg`
-- ----------------------------
DROP TABLE IF EXISTS `courseorg`;
CREATE TABLE `courseorg` (
  `ID` varchar(64) NOT NULL,
  `CourseID` varchar(64) DEFAULT NULL COMMENT '课程级别ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '合作机构用户ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='课程合作机构';

-- ----------------------------
-- Records of courseorg
-- ----------------------------

-- ----------------------------
-- Table structure for `courseparter`
-- ----------------------------
DROP TABLE IF EXISTS `courseparter`;
CREATE TABLE `courseparter` (
  `ID` varchar(64) NOT NULL,
  `CourseID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '参加课程用户ID',
  `IsCancel` tinyint(1) DEFAULT NULL COMMENT '是否取消（取消true 未取消false）',
  `IsFinish` tinyint(1) DEFAULT NULL COMMENT '是否完成（true完成了）',
  `IsTest` tinyint(1) DEFAULT NULL COMMENT 's是否参加了考试（true参加）',
  `TestTime` datetime DEFAULT NULL COMMENT '考试时间',
  `PartTime` datetime DEFAULT NULL COMMENT '参加时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='课程参加人员表';

-- ----------------------------
-- Records of courseparter
-- ----------------------------

-- ----------------------------
-- Table structure for `customerresume`
-- ----------------------------
DROP TABLE IF EXISTS `customerresume`;
CREATE TABLE `customerresume` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `Title` varchar(64) DEFAULT NULL COMMENT '标题',
  `Content` varchar(512) DEFAULT NULL COMMENT '专业技能描述',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='自定义简历内容';

-- ----------------------------
-- Records of customerresume
-- ----------------------------

-- ----------------------------
-- Table structure for `dic`
-- ----------------------------
DROP TABLE IF EXISTS `dic`;
CREATE TABLE `dic` (
  `ID` varchar(64) NOT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `PID` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='基础数据字典';

-- ----------------------------
-- Records of dic
-- ----------------------------
INSERT INTO `dic` VALUES ('aaa', 'industry', null);
INSERT INTO `dic` VALUES ('bbb', 'scale', null);

-- ----------------------------
-- Table structure for `education`
-- ----------------------------
DROP TABLE IF EXISTS `education`;
CREATE TABLE `education` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `SchoolName` varchar(128) DEFAULT NULL COMMENT '学校名称',
  `Academy` varchar(64) DEFAULT NULL COMMENT '学院',
  `Professional` varchar(64) DEFAULT NULL COMMENT '专业',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='教育';

-- ----------------------------
-- Records of education
-- ----------------------------

-- ----------------------------
-- Table structure for `employ`
-- ----------------------------
DROP TABLE IF EXISTS `employ`;
CREATE TABLE `employ` (
  `ID` varchar(64) NOT NULL,
  `TypeID` varchar(64) DEFAULT NULL COMMENT '类型ID',
  `AreaID` varchar(64) DEFAULT NULL COMMENT '地区ID',
  `PostID` varchar(64) DEFAULT NULL COMMENT '岗位ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '发布信息ID',
  `OrgUserID` varchar(64) DEFAULT NULL COMMENT '机构账号ID',
  `Title` varchar(64) DEFAULT NULL COMMENT '标题（包含职位信息）',
  `CompanyName` varchar(128) DEFAULT NULL COMMENT '公司名',
  `PeopleCount` int(11) DEFAULT NULL COMMENT '需求人数',
  `PublishTime` datetime DEFAULT NULL COMMENT '发布时间',
  `EmployAtract` varchar(64) DEFAULT NULL COMMENT '职位诱惑',
  `EmployDesc` text COMMENT '岗位要求',
  `JobResp` text COMMENT '岗位职责',
  `Address` varchar(256) DEFAULT NULL COMMENT '工作地点',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `Salary` varchar(64) DEFAULT NULL COMMENT '薪资',
  `StatusCode` varchar(64) DEFAULT NULL COMMENT '状态（开始，停止）',
  `IsValid` tinyint(1) DEFAULT NULL COMMENT '是否永久有效（true永久有效）',
  `WorkExperience` varchar(64) DEFAULT NULL,
  `EduRequire` varchar(64) DEFAULT NULL,
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='招聘';

-- ----------------------------
-- Records of employ
-- ----------------------------
INSERT INTO `employ` VALUES ('09692006-9762-41c0-9e16-801d310e54c4', '兼职', '1', null, null, null, '电话客服', '第三方', '4', '2017-02-08 16:18:04', '<ol><li>发发发</li></ol>', '<ol><li>水电费发放</li></ol>', '<ol><li>第三个</li></ol>', '是的发送到', null, null, '2343', '待审批', null, '不限工作经验', '不限学历', null, '2017-02-08 16:18:04', null, null, '1', null, null);
INSERT INTO `employ` VALUES ('1', '0', '1', null, '1', '1', '出纳', '湖南朋来信息科技有限公司', '1', '2017-01-18 12:00:00', '顶顶顶顶', '对对对', '顶顶顶顶', '长沙', '2017-01-18 00:00:00', '2017-01-30 00:00:00', '6k/月', '0', '0', '地方', '方法', '1', null, null, null, '1', null, null);
INSERT INTO `employ` VALUES ('1ad7800f-2c03-471e-ab5d-690a130f1572', '实习', null, null, null, null, '新岗位', '朋来', '2', '2017-06-01 16:14:29', '<p>11<br></p>', '<p>11<br><br></p>', '<p>11<br></p>', '随便', null, null, '2000', '待审批', null, '不限工作经验', '本科及以上', null, '2017-06-01 16:14:29', null, null, '1', null, null);
INSERT INTO `employ` VALUES ('1fe678b6-c442-4c26-ac3e-537b50947cc9', '实习', null, null, null, null, '新岗位', '朋来', '2', '2017-06-01 15:33:41', '<p>11<br></p>', '<p>11<br><br></p>', '<p>11<br></p>', '随便', null, null, '2000', '待审批', null, '不限工作经验', '本科及以上', null, '2017-06-01 15:33:41', null, null, '0', null, null);
INSERT INTO `employ` VALUES ('279030e4-1705-47e4-a85a-76c8e0a4e55a', '实习', null, null, null, null, '新岗位', '朋来1', '2', '2017-06-01 16:14:38', '<p>11<br></p>', '<p>11<br><br></p>', '<p>11<br></p>', '随便', null, null, '2000', '待审批', null, '不限工作经验', '本科及以上', null, '2017-06-01 16:14:38', null, null, '0', null, null);
INSERT INTO `employ` VALUES ('37776631-d1fc-4606-acbb-af985b07d07a', '兼职', '1', null, null, null, '电话客服', '安慰人', '2', '2017-04-14 11:38:55', '<ol><li>2</li></ol>', '<ol><li>24</li></ol>', '<ol><li>24</li></ol>', '133', null, null, '123', '待审批', null, '不限工作经验', '不限学历', null, '2017-04-14 11:38:55', null, null, '1', null, null);
INSERT INTO `employ` VALUES ('6d8c7cb0-d4a7-4900-9863-efa6e6c2a659', '兼职', '1', null, null, '88c9ce67-7ad2-4136-b8d4-6bcd4707907c', '会计', '湖南朋来信息科技有限公司', '3', '2017-04-14 16:06:57', '完成基础的财务报表', '勤劳敬业', '111111', '长沙', null, null, '面谈', '待审批', null, '不限工作经验', '不限学历', null, '2017-04-14 16:07:06', null, null, '0', null, null);
INSERT INTO `employ` VALUES ('e80cc08d-3414-4e0a-92a6-383dc875127d', '兼职', '1', null, null, null, '电话客服', '安慰人', '2', '2017-04-14 15:23:09', '<ol><li>2</li></ol>', '<ol><li>24</li></ol>', '<ol><li>24</li></ol>', '133', null, null, '123', '待审批', null, '不限工作经验', '不限学历', null, '2017-04-14 15:23:09', null, null, '1', null, null);
INSERT INTO `employ` VALUES ('faba3c0a-6cf5-4ab9-a957-df5b6e8e74f1', '兼职', '1', null, null, null, '电话客服', '安慰人', '2', '2017-02-08 11:36:28', '<ol><li>2</li></ol>', '<ol><li>24</li></ol>', '<ol><li>24</li></ol>', '133', null, null, '123', '待审批', null, '不限工作经验', '不限学历', null, '2017-02-08 11:36:28', null, null, '1', null, null);
INSERT INTO `employ` VALUES ('fe0dba40-f25b-4da1-a53d-379fbbded10a', '兼职', null, null, null, null, '电话客服', '1111', '2', '2017-06-12 14:47:42', '<p>11<br></p>', '<p>11<br></p>', '<p>11<br></p>', 'where', null, null, '3000', '待审批', null, '不限工作经验', '不限学历', null, '2017-06-12 14:47:42', null, null, '0', null, null);
INSERT INTO `employ` VALUES ('ffa957da-de27-4770-9636-ea2cd59d6f0d', '兼职', '1', null, null, null, '电话客服', '长沙学院', '2', '2017-04-14 16:49:04', '<ol><li>五险一金</li></ol>', '<ol><li>歌功颂德</li></ol>', '<ol><li>管理财务</li></ol>', '长沙', null, null, '薪资不限', '待审批', null, '不限工作经验', '不限学历', null, '2017-04-14 16:49:06', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `employpart`
-- ----------------------------
DROP TABLE IF EXISTS `employpart`;
CREATE TABLE `employpart` (
  `ID` varchar(64) NOT NULL,
  `EmployID` varchar(64) DEFAULT NULL COMMENT '招聘信息ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '参加用户ID',
  `PartTime` datetime DEFAULT NULL COMMENT '发布时间',
  `IsPass` tinyint(1) DEFAULT NULL COMMENT '是否通过招聘（true 通过）',
  `LevelID` varchar(64) DEFAULT NULL COMMENT '评价等级ID',
  `Comment` varchar(256) DEFAULT NULL COMMENT '评论',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='参加招聘';

-- ----------------------------
-- Records of employpart
-- ----------------------------
INSERT INTO `employpart` VALUES ('1', '6d8c7cb0-d4a7-4900-9863-efa6e6c2a659', '8abacd53-f43b-4d28-b8da-ebc82a5df624', '2017-05-10 09:16:53', '1', null, null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `employposition`
-- ----------------------------
DROP TABLE IF EXISTS `employposition`;
CREATE TABLE `employposition` (
  `ID` varchar(64) NOT NULL,
  `PosName` varchar(64) DEFAULT NULL COMMENT '岗位名称',
  `EnCode` varchar(64) DEFAULT NULL COMMENT '岗位编码',
  `SortCode` int(11) DEFAULT NULL COMMENT '排序',
  `PID` varchar(64) DEFAULT NULL COMMENT '父级',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='招聘岗位列表';

-- ----------------------------
-- Records of employposition
-- ----------------------------
INSERT INTO `employposition` VALUES ('0913ef73-02d9-4719-921b-3471fb8e03c5', '小想会计', null, '41', null, null, '2017-02-04 14:57:01', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('152df5ba-c926-4a87-a30a-f678695cf994', '的发广告', null, '1', null, null, '2017-02-04 15:08:31', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('2cdd852e-22ee-4894-ac47-6b5e078e776e', '小会计', null, '4', null, null, '2017-02-04 14:56:46', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('891d4c3b-73b0-4da6-9f84-7779ce4302ad', '电放费', null, '6', null, null, '2017-02-04 15:07:26', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('9142dd7b-d7e1-4d93-a45a-c41bfce808b4', '打得过', null, '3', null, null, '2017-02-04 15:10:41', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('dds1', '电话客服', 'kf', '1', '0', '1', '2017-01-17 16:15:00', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('dds2', '销售支持', 'xs', '2', '0', '1', '2017-01-17 16:15:00', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('dds3', '会计', 'kj', '3', '0', '1', '2017-01-17 16:15:00', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('dds4', '出纳', 'cn', '4', '0', '1', '2017-01-17 16:15:00', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('e248a38d-c3c3-4ff5-a13c-315192c9c433', '地点', null, '2', null, null, '2017-02-04 14:44:30', null, null, '0', null, null);
INSERT INTO `employposition` VALUES ('e6483f11-fc0b-48df-9a07-c24954bcff28', '新岗位', null, '1', null, null, '2017-06-01 15:32:22', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `employpublish`
-- ----------------------------
DROP TABLE IF EXISTS `employpublish`;
CREATE TABLE `employpublish` (
  `ID` varchar(64) NOT NULL,
  `EmployID` varchar(64) DEFAULT NULL COMMENT '招聘信息ID',
  `OrgUserID` varchar(64) DEFAULT NULL COMMENT '发布机构用户ID',
  `ROrgUserID` varchar(64) DEFAULT NULL COMMENT '接收机构用户ID',
  `PublishTime` datetime DEFAULT NULL COMMENT '发布时间',
  `IsRecommend` tinyint(1) DEFAULT NULL COMMENT '是否推荐',
  `IsAgree` tinyint(1) DEFAULT NULL COMMENT '是否审批通过',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='招聘发布';

-- ----------------------------
-- Records of employpublish
-- ----------------------------
INSERT INTO `employpublish` VALUES ('185e74ee-6acd-41b9-9f31-44c8632c3ef5', null, '', 'ab87c79c-0773-4ff4-9b0e-621f9a4f120e', null, null, null, null, '2017-06-01 15:33:41', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('2963acd7-719d-4a05-a26c-4e93ec4d54c5', null, '', '', null, null, null, null, '2017-06-01 16:14:38', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('2c5448ef-284f-4f3d-a94e-5062fd7f2000', null, '', '', null, null, null, null, '2017-06-12 14:47:42', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('37aee8f2-7108-4041-9425-f209636931db', null, '', '', null, null, null, null, '2017-06-01 16:14:29', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('4ffad0b1-9a6d-4954-b4e3-fceff99645a2', null, '', '88c9ce67-7ad2-4136-b8d4-6bcd4707907c', null, null, null, null, '2017-06-01 15:33:41', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('818abc2d-1eef-44fe-80fc-cb4ddcf32c1d', null, '', '8a745b2c-0cab-48b5-a55c-485b21a0b8aa', null, null, null, null, '2017-06-01 15:33:41', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('8fcbeb51-3ab4-45c9-92a5-031e37fa3344', '6d8c7cb0-d4a7-4900-9863-efa6e6c2a659', 'ea8c55fd-e27d-4ad9-b78b-29602f2fa0cc', 'ab87c79c-0773-4ff4-9b0e-621f9a4f120e', null, '1', '1', null, '2017-04-14 16:07:42', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('99f3bcd9-14de-480a-9708-b2602b20835a', null, '', 'ea8c55fd-e27d-4ad9-b78b-29602f2fa0cc', null, null, null, null, '2017-06-01 15:33:41', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('b52a65f2-80e1-460f-a0e1-075a6014c924', null, '', '5409875a-43bf-4767-9f14-cec777fcdce4', null, null, null, null, '2017-06-01 15:33:41', null, null, '0', null, null);
INSERT INTO `employpublish` VALUES ('e2a56035-6b54-4916-b283-321d11c33e5a', null, '', '0898bd54-312b-4e9d-83a7-b456ec9f9e77', null, null, null, null, '2017-06-01 15:33:41', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `employtype`
-- ----------------------------
DROP TABLE IF EXISTS `employtype`;
CREATE TABLE `employtype` (
  `ID` varchar(64) NOT NULL,
  `TypeName` varchar(64) DEFAULT NULL COMMENT '招聘类型名称（兼职，全职，项目）',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='招聘类型';

-- ----------------------------
-- Records of employtype
-- ----------------------------

-- ----------------------------
-- Table structure for `examination`
-- ----------------------------
DROP TABLE IF EXISTS `examination`;
CREATE TABLE `examination` (
  `ID` varchar(64) NOT NULL,
  `CourseID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `FullMark` int(11) DEFAULT NULL COMMENT '满分',
  `PassMark` int(11) DEFAULT NULL COMMENT '通过分数',
  `QuesetionNum` int(11) DEFAULT NULL COMMENT '题目总数',
  `SelectNum` int(11) DEFAULT NULL COMMENT '单选数量',
  `SelectScore` varchar(64) DEFAULT NULL COMMENT '选择分数',
  `TFNum` int(11) DEFAULT NULL COMMENT '判断体数量',
  `TFScore` varchar(64) DEFAULT NULL COMMENT '判断题分数',
  `StatusCode` varchar(64) DEFAULT NULL COMMENT '状态（0待审核1审核通过2审核不通过3停用）',
  `MakingUserID` varchar(64) DEFAULT NULL COMMENT '制定人ID',
  `CheckUserId` varchar(64) DEFAULT NULL COMMENT '审核人ID',
  `CheckTime` datetime DEFAULT NULL COMMENT '审核人时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='考试';

-- ----------------------------
-- Records of examination
-- ----------------------------

-- ----------------------------
-- Table structure for `examinationpaper`
-- ----------------------------
DROP TABLE IF EXISTS `examinationpaper`;
CREATE TABLE `examinationpaper` (
  `ID` varchar(64) NOT NULL,
  `CourseID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `FullMark` int(11) DEFAULT NULL COMMENT '满分',
  `PassMark` int(11) DEFAULT NULL COMMENT '通过分数',
  `QuesetionNum` int(11) DEFAULT NULL COMMENT '题目总数',
  `SelectNum` int(11) DEFAULT NULL COMMENT '单选数量',
  `SelectScore` varchar(64) DEFAULT NULL COMMENT '选择分数',
  `TFNum` int(11) DEFAULT NULL COMMENT '判断体数量',
  `TFScore` varchar(64) DEFAULT NULL COMMENT '判断题分数',
  `StatusCode` varchar(64) DEFAULT NULL COMMENT '状态（0待审核1审核通过2审核不通过3停用）',
  `MakingUserID` varchar(64) DEFAULT NULL COMMENT '制定人ID',
  `CheckUserId` varchar(64) DEFAULT NULL COMMENT '审核人ID',
  `CheckTime` datetime DEFAULT NULL COMMENT '审核人时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='试卷';

-- ----------------------------
-- Records of examinationpaper
-- ----------------------------
INSERT INTO `examinationpaper` VALUES ('5915a225-534f-44f7-b048-dbc806b2db99', '291838d0-712f-4d09-bf1a-1c7746cc4cf5', '6', '4', '3', '1', '2', '2', '2', null, null, null, null, null, '2017-03-10 16:07:41', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `examinationpaperdetail`
-- ----------------------------
DROP TABLE IF EXISTS `examinationpaperdetail`;
CREATE TABLE `examinationpaperdetail` (
  `ID` varchar(64) NOT NULL,
  `PaperID` varchar(64) DEFAULT NULL COMMENT '试卷ID',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '题目类型ID',
  `QuestionID` varchar(64) DEFAULT NULL COMMENT '题目ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='试卷详情';

-- ----------------------------
-- Records of examinationpaperdetail
-- ----------------------------
INSERT INTO `examinationpaperdetail` VALUES ('15915487-d143-441b-a823-219fa022d2e6', 'eba6f296-a602-4ec5-b882-8e0100b75a8e', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-03-10 15:14:19', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('1856880c-a1a5-4707-a490-63e2339befc9', '5423fa3d-d30d-4cf5-a3dc-e27e2d796afe', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-05-31 15:05:14', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('4b0fd848-c493-428f-92b8-b12cb9931fba', 'f39e8486-4e73-4b9e-9bd8-42acf1d2b080', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-06-01 14:53:26', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('54586a65-6cff-4f61-b985-9c28990a169f', '2d05590b-261d-4714-9acb-68e3ef9aeaf1', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-05-31 14:42:31', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('6e49957b-3246-4872-80fa-ea557e7519be', 'eba6f296-a602-4ec5-b882-8e0100b75a8e', '1', '9e4b1c48-ba40-46a9-a031-ca616e442a7d', null, '2017-03-10 15:14:31', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('6ff4b82b-dfa8-45f4-baf1-fd3dffb4415c', 'e8d09a45-928e-46ce-8091-2086a1960e38', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-06-01 16:41:08', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('77b3102e-33f1-4ebf-8d53-66c145392840', 'e94c5a0a-cda0-4c75-a1e5-c0dde84339f1', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-05-31 14:44:30', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('a87702b2-48b7-49c5-aa45-e39e3314af6b', '6eb116f1-7c62-4ba0-8b92-ebaf61602d89', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-05-31 14:42:23', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('a87813a9-7e78-4b7b-8c89-71d7ff997836', '0898979f-e610-408d-b2ee-89e2b8b02204', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-06-01 14:53:38', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('b75d952a-3d82-4d76-be62-3365213fcc77', '595c17c7-ef12-4966-b8b4-6edecbebda0e', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-05-31 14:44:27', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('e0bfa67f-e219-46ef-b303-1f6f2f24c94f', '5915a225-534f-44f7-b048-dbc806b2db99', '1', 'ab2cdaa3-3d76-419a-ad27-40c578bd38e6', null, '2017-03-10 16:07:55', null, null, '0', null, null);
INSERT INTO `examinationpaperdetail` VALUES ('f1b81084-b310-4aec-a103-cae6848ba6c4', '5915a225-534f-44f7-b048-dbc806b2db99', '1', '9e4b1c48-ba40-46a9-a031-ca616e442a7d', null, '2017-03-10 16:07:57', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `examinationpaperuser`
-- ----------------------------
DROP TABLE IF EXISTS `examinationpaperuser`;
CREATE TABLE `examinationpaperuser` (
  `ID` varchar(64) NOT NULL,
  `ExaminationUserID` varchar(64) DEFAULT NULL COMMENT '用户考试ID',
  `CourseID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '题目类型ID',
  `QuestionID` varchar(64) DEFAULT NULL COMMENT '题目ID',
  `SelectAnswer` varchar(4) DEFAULT NULL COMMENT '选择题答案',
  `TFAnswer` tinyint(1) DEFAULT NULL COMMENT '判断体答案',
  `IsRight` tinyint(1) DEFAULT NULL COMMENT '答案是否正确（true正确false错误）',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='学生考试记录';

-- ----------------------------
-- Records of examinationpaperuser
-- ----------------------------

-- ----------------------------
-- Table structure for `examinationuser`
-- ----------------------------
DROP TABLE IF EXISTS `examinationuser`;
CREATE TABLE `examinationuser` (
  `ID` varchar(64) NOT NULL,
  `CourseID` varchar(64) DEFAULT NULL COMMENT '课程ID',
  `PaperID` varchar(64) DEFAULT NULL COMMENT '试卷ID',
  `Mark` int(11) DEFAULT NULL COMMENT '分数',
  `TestTime` datetime DEFAULT NULL COMMENT '考试时间',
  `CommitTime` datetime DEFAULT NULL COMMENT '交卷时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='学生考试';

-- ----------------------------
-- Records of examinationuser
-- ----------------------------

-- ----------------------------
-- Table structure for `file`
-- ----------------------------
DROP TABLE IF EXISTS `file`;
CREATE TABLE `file` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户编号',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '文件类型ID',
  `FileName` varchar(256) DEFAULT NULL COMMENT '文件名',
  `OName` varchar(256) DEFAULT NULL COMMENT '原文件名',
  `FileExt` varchar(16) DEFAULT NULL COMMENT '文件扩展名',
  `FilePath` varchar(256) DEFAULT NULL,
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='文件表';

-- ----------------------------
-- Records of file
-- ----------------------------
INSERT INTO `file` VALUES ('6-6-6', '84', '1', '20170103172120635gallery-8.jpg', '20170103172120635gallery-8.jpg', '.jpg', null, '84', null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `filetype`
-- ----------------------------
DROP TABLE IF EXISTS `filetype`;
CREATE TABLE `filetype` (
  `ID` varchar(64) NOT NULL,
  `TypeName` varchar(64) DEFAULT NULL COMMENT '文件分类名称',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='文件类型';

-- ----------------------------
-- Records of filetype
-- ----------------------------

-- ----------------------------
-- Table structure for `messagereceived`
-- ----------------------------
DROP TABLE IF EXISTS `messagereceived`;
CREATE TABLE `messagereceived` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '接收用户ID',
  `MessageID` varchar(64) DEFAULT NULL COMMENT '消息ID',
  `IsRead` tinyint(1) DEFAULT NULL COMMENT '是否已读（true已读false未读）',
  `ReceivedTime` datetime DEFAULT NULL COMMENT '接收时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='接收消息表';

-- ----------------------------
-- Records of messagereceived
-- ----------------------------

-- ----------------------------
-- Table structure for `messagesend`
-- ----------------------------
DROP TABLE IF EXISTS `messagesend`;
CREATE TABLE `messagesend` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '发送用户编号',
  `MessageType` varchar(64) DEFAULT NULL COMMENT '标签',
  `Title` varchar(64) DEFAULT NULL COMMENT '标题',
  `Content` varchar(256) DEFAULT NULL COMMENT '内容',
  `SendTime` datetime DEFAULT NULL COMMENT '发送时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='发送消息表';

-- ----------------------------
-- Records of messagesend
-- ----------------------------

-- ----------------------------
-- Table structure for `organize`
-- ----------------------------
DROP TABLE IF EXISTS `organize`;
CREATE TABLE `organize` (
  `ID` varchar(64) NOT NULL,
  `OrgType` varchar(64) DEFAULT NULL COMMENT '机构类型',
  `OrgProp` varchar(64) DEFAULT NULL COMMENT '机构性质',
  `LogoID` varchar(64) DEFAULT NULL COMMENT '缩略图',
  `OrgName` varchar(64) DEFAULT NULL COMMENT '机构名称',
  `OrgCode` varchar(128) DEFAULT NULL COMMENT '机构编码',
  `OrgPeopleNumber` varchar(64) DEFAULT NULL COMMENT '公司人数',
  `OrgContact` varchar(64) DEFAULT NULL COMMENT '机构联系人',
  `Phone` varchar(64) DEFAULT NULL,
  `Telphone` varchar(64) DEFAULT NULL COMMENT '机构联系人电话',
  `Address` varchar(256) DEFAULT NULL COMMENT '公司地址',
  `WeChat` varchar(128) DEFAULT NULL COMMENT '微信',
  `Email` varchar(256) DEFAULT NULL COMMENT '邮箱',
  `Fax` varchar(64) DEFAULT NULL COMMENT '传真',
  `IsEnable` tinyint(1) DEFAULT NULL COMMENT '是否有效true有效',
  `Introduction` text COMMENT '公司介绍',
  `ReMark` varchar(256) DEFAULT NULL COMMENT '备注',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `IndID` varchar(64) DEFAULT NULL COMMENT '行业ID',
  `ScaleID` varchar(64) DEFAULT NULL COMMENT '规模ID',
  `OffSite` varchar(64) DEFAULT NULL COMMENT '官网地址',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='机构信息表';

-- ----------------------------
-- Records of organize
-- ----------------------------
INSERT INTO `organize` VALUES ('0898bd54-312b-4e9d-83a7-b456ec9f9e77', '00971df6-4316-4b90-85b8-3681c4d3a867', '0', null, '长沙学院', '01', null, '1', '1', '1', '1', '1', '1', '1', '1', null, null, null, '2017-06-01 11:08:09', null, null, null, null, null, null, null, null);
INSERT INTO `organize` VALUES ('5409875a-43bf-4767-9f14-cec777fcdce4', '8eabdc8f-7e20-47f4-8acf-1c4678d53559', '2', null, '长沙学院', 'CCSU', null, '123', null, null, null, null, null, null, '1', null, null, null, '2017-01-12 11:02:24', null, '2017-01-12 11:22:18', null, null, null, null, null, null);
INSERT INTO `organize` VALUES ('5e242083-8c35-4231-bcb7-f498e060c9f1', '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '1', null, '123', '22222', null, null, null, null, null, null, null, null, '1', null, null, null, '2017-01-12 11:23:49', null, null, '1', null, null, null, null, null);
INSERT INTO `organize` VALUES ('86da42e0-b9f1-4d72-a621-deec005b6ec9', '00971df6-4316-4b90-85b8-3681c4d3a867', '1', null, '253', '1', null, '1', '1', '1', '1', '1', '1', '1', '1', null, null, null, '2017-06-01 11:09:20', null, '2017-06-01 11:10:55', '1', null, null, null, null, null);
INSERT INTO `organize` VALUES ('88c9ce67-7ad2-4136-b8d4-6bcd4707907c', 'abfc94e9-cada-46f9-9a20-1ad6423062c8', '1', null, '朋来信息', 'Penglai', null, null, null, null, null, null, null, null, '1', null, null, null, '2017-02-07 16:02:02', null, '2017-02-07 16:02:11', null, null, null, null, null, null);
INSERT INTO `organize` VALUES ('8a745b2c-0cab-48b5-a55c-485b21a0b8aa', '8eabdc8f-7e20-47f4-8acf-1c4678d53559', '2', null, '中南大学', 'ZNDX', null, null, null, null, null, null, null, null, '1', null, null, null, '2017-04-17 14:43:10', null, null, null, null, null, null, null, null);
INSERT INTO `organize` VALUES ('ab87c79c-0773-4ff4-9b0e-621f9a4f120e', '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '2', null, '平台管理', 'Plamform', null, null, null, null, null, null, null, null, '1', null, null, null, '2017-01-16 16:10:59', null, null, null, null, null, null, null, null);
INSERT INTO `organize` VALUES ('ea8c55fd-e27d-4ad9-b78b-29602f2fa0cc', '8eabdc8f-7e20-47f4-8acf-1c4678d53559', '2', null, '湖南大学', 'HNDX', null, null, null, null, null, null, null, null, '1', null, null, null, '2017-04-17 14:42:51', null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `resumebaseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `resumebaseinfo`;
CREATE TABLE `resumebaseinfo` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户编号',
  `TrueName` varchar(64) DEFAULT NULL COMMENT '真实姓名',
  `Gender` varchar(4) DEFAULT NULL COMMENT '性别',
  `BirthDate` datetime DEFAULT NULL COMMENT '出生年月',
  `Education` varchar(64) DEFAULT NULL COMMENT '教育背景',
  `Address` varchar(64) DEFAULT NULL COMMENT '居住地',
  `Phone` varchar(16) DEFAULT NULL COMMENT '手机',
  `Email` varchar(64) DEFAULT NULL COMMENT '邮箱',
  `HeadPicID` varchar(64) DEFAULT NULL COMMENT '头像ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `Age` int(11) DEFAULT NULL COMMENT '年龄',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='简历基本信息';

-- ----------------------------
-- Records of resumebaseinfo
-- ----------------------------
INSERT INTO `resumebaseinfo` VALUES ('a', '8abacd53-f43b-4d28-b8da-ebc82a5df624', '琳琳', '0', '2017-06-23 00:00:00', null, null, null, null, null, null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for `resumeconfig`
-- ----------------------------
DROP TABLE IF EXISTS `resumeconfig`;
CREATE TABLE `resumeconfig` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '类型（radio， check，customer）',
  `ConfigName` varchar(64) DEFAULT NULL COMMENT '配置名称',
  `Radio` tinyint(4) DEFAULT NULL COMMENT '选择项值（0个人信息（附照片）1 无照片）',
  `IsCheck` tinyint(1) DEFAULT NULL COMMENT '是否选择了(true 已选择 false 未选择)',
  `CustomerID` varchar(64) DEFAULT NULL COMMENT '自定义ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='简历配置';

-- ----------------------------
-- Records of resumeconfig
-- ----------------------------

-- ----------------------------
-- Table structure for `role`
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role` (
  `ID` varchar(64) NOT NULL,
  `OrgID` varchar(64) DEFAULT NULL,
  `AccountTypeID` varchar(64) DEFAULT NULL COMMENT '类型ID',
  `RoleName` varchar(64) DEFAULT NULL COMMENT '角色名称',
  `RoleCode` varchar(128) DEFAULT NULL COMMENT '角色编码',
  `Remark` varchar(256) DEFAULT NULL COMMENT '备注',
  `SortCode` int(11) DEFAULT NULL,
  `IsEdit` tinyint(1) DEFAULT NULL COMMENT '是否可编辑（true 可编辑false不可编辑）',
  `IsDelete` tinyint(1) DEFAULT NULL COMMENT '是否可删除（true可删除）',
  `IsEnable` tinyint(1) DEFAULT NULL COMMENT '是否有效（true有效',
  `AppStyle` varchar(64) DEFAULT NULL COMMENT '登录类型0：学生，1：老师，2企业',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色表';

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('0b395a53-d93d-426c-a29d-61b7bd8dd19c', null, 'abfc94e9-cada-46f9-9a20-1ad6423062c8', '企业招聘人员', 'EnEmpoly', null, '1', '0', '0', '1', '2', null, '2017-02-08 09:51:40', null, null, null, null, null);
INSERT INTO `role` VALUES ('45f91ddc-0f21-4dc4-a439-3447664d859b', null, '8eabdc8f-7e20-47f4-8acf-1c4678d53559', '学生', 'Student', null, '7', '1', '1', '1', '0', null, '2017-04-13 10:12:46', null, '2017-04-13 10:13:33', null, null, null);
INSERT INTO `role` VALUES ('4e27e7f0-8542-42f6-a032-746106384d62', null, '00971df6-4316-4b90-85b8-3681c4d3a867', '15', '001', '1234', '12', '1', '0', '1', null, null, '2017-06-01 11:15:42', null, '2017-06-01 11:18:21', '1', null, null);
INSERT INTO `role` VALUES ('5d6f5486-9542-4789-ac16-e06fbb39e9ed', null, '8eabdc8f-7e20-47f4-8acf-1c4678d53559', '学校辅导员', 'Helper', null, '4', '0', '0', '1', '1', null, '2017-02-07 11:00:28', null, null, null, null, null);
INSERT INTO `role` VALUES ('6046a949-89d5-47ad-a965-79b44a45996e', null, '8eabdc8f-7e20-47f4-8acf-1c4678d53559', '学校管理员', 'SchoolAdmin', null, '3', '0', '0', '1', '1', null, '2017-01-17 17:24:46', null, null, null, null, null);
INSERT INTO `role` VALUES ('628e2960-707e-4574-878c-c50ad45a3ec8', null, '8eabdc8f-7e20-47f4-8acf-1c4678d53559', '老师', 'Teacher', null, '8', '0', '0', '1', '1', null, '2017-04-19 09:49:49', null, null, null, null, null);
INSERT INTO `role` VALUES ('6db2296a-3b63-4d95-95f7-4d62356ee3e8', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '213', '123', null, '123', '1', '1', '1', '0', null, '2017-01-10 16:10:08', null, null, '1', null, null);
INSERT INTO `role` VALUES ('ca45a158-5628-41d8-9d41-28f8d007132f', null, 'abfc94e9-cada-46f9-9a20-1ad6423062c8', '企业专业人员', 'EnPr', null, '6', '0', '0', '1', '2', null, '2017-02-08 10:01:30', null, null, null, null, null);
INSERT INTO `role` VALUES ('e36b756a-dcce-4aa8-b00a-e8e31db6641a', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '普通管理员', 'GAdmin', null, '2', '0', '0', '1', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `role` VALUES ('fc2d01c3-7c56-44a0-948d-cb263c42c0b2', null, '9fc09f5c-6d1f-4e4c-9019-3bad0de106ed', '系统管理员', 'administrator', '系统管理员1234', '1', '1', '1', '1', '1', null, '2017-01-10 14:13:45', null, '2017-02-08 16:12:55', null, null, null);

-- ----------------------------
-- Table structure for `roleauthorize`
-- ----------------------------
DROP TABLE IF EXISTS `roleauthorize`;
CREATE TABLE `roleauthorize` (
  `ID` varchar(64) NOT NULL,
  `RoleID` varchar(64) DEFAULT NULL COMMENT '角色ID',
  `AuthorizeID` varchar(64) DEFAULT NULL COMMENT '权限ID',
  `ObjectType` varchar(64) DEFAULT NULL COMMENT '对象分类1-角色2-部门-3用户',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色权限表';

-- ----------------------------
-- Records of roleauthorize
-- ----------------------------
INSERT INTO `roleauthorize` VALUES ('01dde585-5448-4099-89cd-6000a7c2cb29', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', 'e60c98cd-bc6a-4af6-9f17-791f01c973d2', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('063c1f86-00b0-44d7-9c8f-4f94b2f0675b', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '4f5fb813-eb35-4ad3-a360-56d7fbd3e90b', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('0bbf8cd9-0bf8-4dd0-86a1-424460ae26a9', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '5e0da7b0-f61b-429e-9d2a-eb4b6ad68001', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('132dea06-d0f5-447a-88b6-f9abb8e04fef', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'e60c98cd-bc6a-4af6-9f17-791f01c973d2', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('14aa32a0-f065-4ab7-a789-b9740a6a3938', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'c2026ac6-ccf5-4d0b-92f4-19f6ed234b94', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('14cb6a37-75fc-4764-a976-fff930e1a946', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '7362541b-2c8e-45a5-aa0d-ddad160fead1', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('16d615ba-320b-496a-8909-5ab914afb65f', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '33fab425-1513-4eeb-9288-a52d0a8afa34', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('17abac30-db76-4e37-8ee1-7ead45a984ea', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'db27e833-1899-4310-8dce-0aa5daaeb7e1', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('20127674-8aec-4ee2-b025-cc560ee366e1', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'b97c8459-8563-476a-8982-2c3f3f073475', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('205cd17c-933b-49dc-8f9d-3b0865a3364e', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '2605ca30-0caf-40e9-a882-c309ce1673ba', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('235cab05-86cb-4e02-a847-1885b1cb9b79', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '24bc7ace-56c5-49b2-a2ab-eb019fd16c60', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('282f0f3d-0b0e-45fa-b7cd-341dba84719a', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '7719b1d1-d684-41ec-be88-34b063a72378', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('2c4be74c-df68-41ce-a141-a995c76ca00a', '4e27e7f0-8542-42f6-a032-746106384d62', '9de9a74d-8845-431c-a189-24dae9511f27', '1', null, '2017-06-01 11:18:21', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('2c935ef7-0879-449d-bbd7-a8f58c043fe1', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'd15c482f-c570-4269-be62-2e65a26df98e', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('30c752a8-ce70-4d5b-942b-5e916db6cb36', '6046a949-89d5-47ad-a965-79b44a45996e', '', '1', null, '2017-01-17 17:24:46', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('342d3133-778c-4817-a4c6-04e44dfff4d3', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '8f5e5397-c72f-4c82-8b5a-f1f74ae58993', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('3e28dd69-e8b3-4f58-ad76-3d6f112e7f08', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '0143dac8-e3b4-43e2-bc5c-932b44a7978e', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('42469e54-3ebb-433a-b205-300c2cb4b116', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'aedc9263-2dcf-4adf-a5ac-0fef5f517b67', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('42f2595e-fed6-4ea8-aee7-e11df64f010f', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'e8bd2f6b-cca9-49fb-9658-6c8be3c3afb9', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('43708dea-5e30-4f2b-aecb-acfcf4105242', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('4cb4b38e-f916-45d3-98c5-4881f7ba34e0', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'f4e93a02-2efd-48f0-9ea9-7a5ee21fea4d', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('4f10433c-333e-484e-b1bd-bf45707f3f2b', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '629232fa-9615-47ce-98ca-4e3c5d358fe7', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('4fbf6a83-f99c-4cf0-81c6-094e4cb5efe8', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '0c05d42f-8b86-4949-9495-e57e5941b5ed', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('5286aff9-b44e-4972-ae3a-dc2c3bc8847f', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'd0bba16f-8f63-41d7-9190-e030c4b85e96', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('5a2cf01c-589f-45c1-8d77-45b9ea81b56a', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '9b1e604e-ba48-499f-9610-dfb239ebdf7c', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('5f3c38ef-90c8-4ec5-bffe-8893c19f5e0e', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '6d8b8a2c-9e57-422e-ae1b-63580a4dc8db', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('6475fa37-c8b3-45b8-bcfa-bb8fdc7a9b12', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '4b2ac8a8-326b-4400-80b1-fde2608f0eaf', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('69c8f664-7747-4504-87e3-a815956f7030', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '175cec55-9d61-4df1-8054-1715a44a7c7f', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('6b21d49a-2af0-4067-bf4d-a749cc12cffe', '4e27e7f0-8542-42f6-a032-746106384d62', '3356bc63-c5fd-4c75-a2fc-a7ab33c9bfdd', '1', null, '2017-06-01 11:18:21', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('6e67d3d3-f996-4f18-aef9-653a3f9e52f4', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '49469d17-7d29-4331-ba32-8118ad21491e', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('6e721269-f693-40f0-aaa2-32b7398eb7be', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '6b371db0-8be4-4fd7-9044-7bea7d07f47e', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('6fe0b08f-0a03-49dc-9c9e-43b16bd75dc9', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '8f5e5397-c72f-4c82-8b5a-f1f74ae58993', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('7307ccdb-bb9b-40b6-ab00-ab72e421ef5b', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '809d8f00-4505-48f4-8196-dc9c98da7df6', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('76a3104f-363c-467b-aa6a-9818d1d38509', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '2605ca30-0caf-40e9-a882-c309ce1673ba', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('76d4f3d1-fcc0-46ee-b3a8-df63a8b7d749', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'dd8b4e66-2fe6-4dd1-bab1-2cda22f20dee', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('77050786-ffc6-44b8-84a1-833c12f20028', '628e2960-707e-4574-878c-c50ad45a3ec8', '', '1', null, '2017-04-19 09:49:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('77cc3da5-e49e-4eed-bbe6-e3906e762ac2', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'd4d0349f-5b9d-4b49-a94a-56a841b62531', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('7870daca-f1e5-4c29-a278-1cd1c5a5a8ff', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '77e0c04b-5f74-4724-9410-b51b0eb36f11', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('7b800109-faa2-4f6a-b8b6-53bedc0d28da', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'e60bfeb3-61f8-41e0-9f17-7e3d9240394e', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('7bfc3d04-286b-4d00-b055-3611266f6e76', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'b7ed4022-8871-4e36-a0de-08a3aafa5dee', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('7e218cbe-1d92-4913-baa4-e47be2a21673', '45f91ddc-0f21-4dc4-a439-3447664d859b', '', '1', null, '2017-04-13 10:13:33', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('8292b9c8-eaeb-461b-a4dd-01650735708f', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '343a4cad-fd4e-4b21-8215-f116f3773ec5', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('833daf53-b6a2-479a-a0c5-97eab8737d56', '6db2296a-3b63-4d95-95f7-4d62356ee3e8', '24bc7ace-56c5-49b2-a2ab-eb019fd16c60', '1', null, '2017-01-10 16:10:08', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('8494bb08-e64a-418d-b189-1a215591c60f', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '60675e10-6989-48d7-9ace-54212f1605b3', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('8bbc997b-bec0-4860-8c0f-4ed70fdbf01d', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '5bdd72bc-f0c1-4a10-bb25-dd7093e100e6', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('8c1d84a1-05c8-47b2-a139-d66720645bf9', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '420f221c-6ed5-4b6f-b87e-b4bca2752510', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('91837398-ad3c-4326-b625-8f61d6348352', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '957df709-29d1-4a2d-8f5f-090004c8475a', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('920cc2f5-0099-4e4a-97e6-3c409b7e1550', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'b2eb97ea-fba2-4dcc-a61a-02d7af2065d1', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('9745ef0d-4336-42a9-ab57-388671572b6c', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '1238a352-26d4-44a5-8660-6539f3189f49', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('a15a22f3-075a-45d7-9ca9-6726175243fb', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('a7229a14-f040-4372-be5a-ef302319230e', 'ca45a158-5628-41d8-9d41-28f8d007132f', '', '1', null, '2017-02-08 10:01:30', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('a9204cde-73f2-42d5-a1ef-9dbc4c1a48de', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '18ab9ba8-e81d-4f63-ad24-17a67490d28c', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('a9f2ac48-d30a-4bae-8f4f-cc2530bda00e', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '550747d7-e51b-4b29-89ab-573b7da5881e', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('ab3ec200-81a5-48a2-b664-70d9f12f7a4c', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '59c42ae5-1950-4e46-a311-8cc10fefe16c', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('ad37acf4-2bc6-4aca-bfc4-e2fd8c3bd1dc', '0b395a53-d93d-426c-a29d-61b7bd8dd19c', '', '1', null, '2017-02-08 09:51:40', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('ae802b0a-eb81-4e75-9ed6-a792ffa1845e', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'a6e2359e-59e0-45fc-95b8-b33762839902', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('b1ed91f5-7074-4aa5-ad3d-028fae468a05', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'd1209e7f-9c15-414e-a77e-57f44965d3a0', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('b2eeee2e-8130-40c3-870f-04af70411a9b', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '9ac92b44-11d2-4ef0-aca5-ec0cdefd1574', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('b3ed6219-4716-4c56-a22f-fdb9c014948f', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'ea4de15e-eaa4-492c-8504-61349c45f05d', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('b6b0ffa1-8f1d-4ee3-84a6-cc4025ba407d', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', 'a6e2359e-59e0-45fc-95b8-b33762839902', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('bbb59374-fc4e-4f8a-a4e6-28483ae09ef3', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'c111d6c7-713f-4b5b-b6fb-2516edbcd997', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('bcd9da85-3e25-4cbc-bf96-cc47f2b2f28e', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '21b45422-e317-461d-a17f-f77299083efe', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('bf770683-baa7-4628-8cfd-65a0133cc30e', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '1ac7cd1e-1bf4-4427-bc78-2b4a830c7208', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('c5935636-34a9-4ae5-a974-b20c46c89695', '6db2296a-3b63-4d95-95f7-4d62356ee3e8', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', '1', null, '2017-01-10 16:10:08', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('c758c0f0-7838-4ee3-8aa9-0d4d2d5076eb', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'aee22449-0428-4ccb-877a-d726f3ffcfdf', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('c89f3e9f-d905-46fb-af43-2bc3722b5ec1', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', 'c2026ac6-ccf5-4d0b-92f4-19f6ed234b94', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('c9ca29ae-4224-430c-a516-55c3b6c5974c', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '30ef22a6-928a-4ac6-a679-8e1d6ed29b31', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('c9eaddce-4b0e-43fe-9106-48d8737df496', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '34be011c-ce25-479a-8630-3d50b9e1a0f5', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('cb2d255c-c130-43e4-9203-889d31a497af', '6db2296a-3b63-4d95-95f7-4d62356ee3e8', '2605ca30-0caf-40e9-a882-c309ce1673ba', '1', null, '2017-01-10 16:10:08', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('ccd92fd7-cb34-4ce0-8bc6-4e924ad08303', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '420f221c-6ed5-4b6f-b87e-b4bca2752510', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('cdd5db47-c3bd-4b86-822b-99f7c0b9a8ee', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '515332e6-dd95-420b-9c58-bd9196af11f4', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('d1602e28-f005-4ddc-bbd6-9a4b3607b844', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'dc515acc-d493-4b33-bd46-bff6c6d41ec1', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('d161e464-80db-461a-a30c-755c1e5c0146', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '41dd47e3-c146-4f05-bf49-4ce4d1f6ca3f', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('d3850a72-4967-41be-b637-c16ea1af040e', '6db2296a-3b63-4d95-95f7-4d62356ee3e8', 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', '1', null, '2017-01-10 16:10:08', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('d747a64e-eae3-4d08-9acf-450c27e1952f', '4e27e7f0-8542-42f6-a032-746106384d62', '332493df-9224-41cc-825f-3a92103cd66b', '1', null, '2017-06-01 11:18:21', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('e059c7a9-25ef-44e7-8c79-48ed1f58de05', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'd433f459-84da-45c2-aade-772e5128d3d1', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('e42f1d0a-0124-452f-97a6-352ad23c97ee', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '4d420626-d0af-4578-8d88-164c70a1357d', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('e4badb5d-5d6d-408f-a54f-3804e2d08ae2', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '24bc7ace-56c5-49b2-a2ab-eb019fd16c60', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('e4ed5f3f-3efc-40fc-a400-0edaf9f8056f', '4e27e7f0-8542-42f6-a032-746106384d62', '837843f1-2304-4361-97e5-5145a9931625', '1', null, '2017-06-01 11:18:21', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('e59cccf4-8c63-43bc-8ea9-17fcac7cebb2', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '17b3a804-3d4c-44d4-9a81-f46229541e62', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('e6cae6b1-72b7-4f2d-bd45-ba574e7dcc9d', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '47ffad9a-92d8-4e5a-8c42-4d4f9700c582', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('e9d290ff-bde2-4352-98e2-5dc62766ee66', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '9b1e604e-ba48-499f-9610-dfb239ebdf7c', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('eabee340-a6ec-4eb5-ab1e-37d0dc988d88', '5d6f5486-9542-4789-ac16-e06fbb39e9ed', '', '1', null, '2017-02-07 11:00:28', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('ef94ee42-1f70-4107-a2cb-b238389aaf0c', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '30def16f-d07b-4513-a472-747ef0cf391d', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('efe68bb4-ae4c-45de-89a0-5d9ef60ea151', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '5086f847-5f31-40b1-aa1d-d3309139ca6a', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('f2941d95-19d0-4706-b610-4a45f4c07008', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '0143dac8-e3b4-43e2-bc5c-932b44a7978e', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('f5b93a7b-5dbd-4b19-b79a-fefff2cb5297', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '9fb08436-030f-4c97-a978-35208aab2cda', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('f833290d-8084-4326-bcc1-614d7786b5ad', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'df202a67-e340-433b-b3bc-4ed3aa8fd1d5', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('f89f9945-80e7-4404-a2e4-f699004f09d5', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '4f4954e9-3663-435e-8b04-4b1b5ee3f84b', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('f8aec1e6-afe2-4984-9d0f-2fa212e271ce', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '6344daaa-4255-4634-8870-3102bbfb6eba', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('f92d8687-0c09-42c3-86f9-2e25478930f3', 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '30ef22a6-928a-4ac6-a679-8e1d6ed29b31', '1', null, '2017-01-16 16:09:49', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('fe09492e-c006-4f98-ab47-ac7134298979', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', 'ab537161-700e-44e4-bab3-b1756feb7f66', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);
INSERT INTO `roleauthorize` VALUES ('fe16a2b8-ff68-4411-8b94-a3cb8601099a', 'fc2d01c3-7c56-44a0-948d-cb263c42c0b2', '8c452931-d5ed-47ed-9dd4-1179d400ebee', '1', null, '2017-02-08 16:12:55', null, null, null, null, null);

-- ----------------------------
-- Table structure for `skill`
-- ----------------------------
DROP TABLE IF EXISTS `skill`;
CREATE TABLE `skill` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `Content` varchar(512) DEFAULT NULL COMMENT '专业技能描述',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='专业技能';

-- ----------------------------
-- Records of skill
-- ----------------------------

-- ----------------------------
-- Table structure for `skill2`
-- ----------------------------
DROP TABLE IF EXISTS `skill2`;
CREATE TABLE `skill2` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `Content` varchar(512) DEFAULT NULL COMMENT '专业技能描述',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='专业技能';

-- ----------------------------
-- Records of skill2
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_feedback`
-- ----------------------------
DROP TABLE IF EXISTS `sys_feedback`;
CREATE TABLE `sys_feedback` (
  `ID` varchar(64) NOT NULL,
  `Content` varchar(512) DEFAULT NULL COMMENT '反馈内容',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `Title` varchar(64) DEFAULT NULL COMMENT '标题',
  `Reply` text COMMENT '回复',
  `IsReply` tinyint(4) DEFAULT NULL COMMENT '是否回复',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='意见反馈';

-- ----------------------------
-- Records of sys_feedback
-- ----------------------------

-- ----------------------------
-- Table structure for `teachergroup`
-- ----------------------------
DROP TABLE IF EXISTS `teachergroup`;
CREATE TABLE `teachergroup` (
  `ID` varchar(64) NOT NULL,
  `GName` varchar(128) DEFAULT NULL COMMENT '团队名称',
  `PhotoID` varchar(64) DEFAULT NULL COMMENT '图片ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='教师团队';

-- ----------------------------
-- Records of teachergroup
-- ----------------------------

-- ----------------------------
-- Table structure for `teachergroupuser`
-- ----------------------------
DROP TABLE IF EXISTS `teachergroupuser`;
CREATE TABLE `teachergroupuser` (
  `ID` varchar(64) NOT NULL,
  `GroupID` varchar(64) DEFAULT NULL COMMENT '团队ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='教师团队成员';

-- ----------------------------
-- Records of teachergroupuser
-- ----------------------------

-- ----------------------------
-- Table structure for `testmaterials`
-- ----------------------------
DROP TABLE IF EXISTS `testmaterials`;
CREATE TABLE `testmaterials` (
  `ID` varchar(64) NOT NULL,
  `TestName` varchar(64) DEFAULT NULL COMMENT '试题名称',
  `UploadTime` datetime DEFAULT NULL COMMENT '上传时间',
  `UploadUserID` varchar(64) DEFAULT NULL COMMENT '上传用户ID',
  `FileID` varchar(64) DEFAULT NULL COMMENT '文件ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='试题资料';

-- ----------------------------
-- Records of testmaterials
-- ----------------------------

-- ----------------------------
-- Table structure for `traindata`
-- ----------------------------
DROP TABLE IF EXISTS `traindata`;
CREATE TABLE `traindata` (
  `ID` varchar(64) NOT NULL,
  `TrainID` varchar(64) DEFAULT NULL COMMENT '培训信息ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '上传用户ID',
  `TypeID` varchar(64) DEFAULT NULL COMMENT '类型ID',
  `FileID` varchar(64) DEFAULT NULL COMMENT '文件ID',
  `UploadTime` datetime DEFAULT NULL COMMENT '上传时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='培训资料';

-- ----------------------------
-- Records of traindata
-- ----------------------------
INSERT INTO `traindata` VALUES ('814a4c23-ff09-44fa-8948-e463c1c27ea8', '00ab4c4c-6a29-4b46-9db4-fd95ab54f09a', null, 'pdf', '/Courseware/20170308101923044养老平台框架图.pdf', '2017-03-08 10:19:52', null, '2017-03-08 10:19:52', null, null, '0', null, null);
INSERT INTO `traindata` VALUES ('affc6a9f-858e-4e5c-927f-dfdbdc5b61ce', 'abf7a68c-3a29-4149-af79-2f2347e2f360', null, 'png', '/Courseware/20170308111010262图片2.png', '2017-03-08 11:10:34', null, '2017-03-08 11:10:34', null, null, '0', null, null);
INSERT INTO `traindata` VALUES ('d0215791-65d3-4378-96e2-87aabad0e88c', '00ab4c4c-6a29-4b46-9db4-fd95ab54f09a', null, 'docx', '/Courseware/20170308101940827ERP交互问题.docx', '2017-03-08 10:19:53', null, '2017-03-08 10:19:53', null, null, '0', null, null);
INSERT INTO `traindata` VALUES ('df6b95f9-3ffa-45e5-8b10-b406b30d2732', '00ab4c4c-6a29-4b46-9db4-fd95ab54f09a', null, 'png', '/Courseware/20170308101931468Nodata.png', '2017-03-08 10:19:52', null, '2017-03-08 10:19:52', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `trainexperience`
-- ----------------------------
DROP TABLE IF EXISTS `trainexperience`;
CREATE TABLE `trainexperience` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `OrgName` varchar(128) DEFAULT NULL COMMENT '机构名',
  `Position` varchar(64) DEFAULT NULL COMMENT '职位',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `WorkContent` varchar(512) DEFAULT NULL COMMENT '工作内容',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='培训经历';

-- ----------------------------
-- Records of trainexperience
-- ----------------------------

-- ----------------------------
-- Table structure for `traininfo`
-- ----------------------------
DROP TABLE IF EXISTS `traininfo`;
CREATE TABLE `traininfo` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '发布人',
  `PhotoID` varchar(512) DEFAULT NULL COMMENT '图片编号',
  `Host` varchar(128) DEFAULT NULL COMMENT '举办单位',
  `Address` varchar(128) DEFAULT NULL COMMENT '活动地点',
  `StatusCode` varchar(64) DEFAULT NULL,
  `Content` text COMMENT '培训信息详情',
  `TrainTitle` varchar(64) DEFAULT NULL,
  `LimitNumber` int(11) DEFAULT NULL COMMENT '参加人数上限',
  `PartNumber` int(11) DEFAULT NULL COMMENT '已经参加人数',
  `PublishTime` datetime DEFAULT NULL COMMENT '发布时间',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `ApplySTime` datetime DEFAULT NULL COMMENT '活动开始报名时间',
  `ApplyETime` datetime DEFAULT NULL COMMENT '活动结束报名时间',
  `Summary` text,
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='培训信息';

-- ----------------------------
-- Records of traininfo
-- ----------------------------
INSERT INTO `traininfo` VALUES ('3609ccdc-26f0-4e71-b140-41c854abb00d', null, null, '22', '22', '0', null, '22', null, null, null, '2017-06-29 10:26:10', '2017-06-30 10:26:18', '2017-05-31 10:26:25', '2017-06-13 10:26:28', '<p>222222<br></p>', null, '2017-05-31 10:26:43', null, '2017-05-31 11:12:17', '0', null, null);
INSERT INTO `traininfo` VALUES ('70377aa9-dd76-46c8-9d53-026ef172b7d0', null, null, '11', '11', '0', '1111', '11', null, null, null, '2017-06-20 10:21:17', '2017-06-22 11:20:52', '2017-05-31 10:21:40', '2017-06-14 10:21:44', null, null, '2017-05-31 10:23:06', null, null, '0', null, null);
INSERT INTO `traininfo` VALUES ('ac248001-a81d-4dd5-bf62-d962a4aed518', null, '/Image/20170308172142861素材中国sccnn.com_2016042387642718t2bt_01.jpg', '水电费', '广场', '1', '是的方法', '双方都', '0', null, null, '2017-03-09 17:21:17', '2017-03-09 18:21:21', '2017-03-08 17:21:26', '2017-03-08 19:21:29', null, null, '2017-03-08 17:21:48', null, null, '0', null, null);
INSERT INTO `traininfo` VALUES ('f113af2c-f2ff-41b2-a200-599864c87f13', null, null, '22', '22', '0', null, '22', null, null, null, '2017-06-29 10:26:10', '2017-06-30 10:26:18', '2017-05-31 10:26:25', '2017-06-13 10:26:28', null, null, '2017-05-31 10:28:01', null, null, '0', null, null);

-- ----------------------------
-- Table structure for `trainparter`
-- ----------------------------
DROP TABLE IF EXISTS `trainparter`;
CREATE TABLE `trainparter` (
  `ID` varchar(64) NOT NULL,
  `TrainID` varchar(64) DEFAULT NULL COMMENT '培训信息ID',
  `UserID` varchar(64) DEFAULT NULL COMMENT '参加培训用户ID',
  `IsCancel` tinyint(1) DEFAULT NULL COMMENT '是否取消（取消true 未取消false）',
  `PartTime` datetime DEFAULT NULL COMMENT '参加时间',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='培训参加人员表';

-- ----------------------------
-- Records of trainparter
-- ----------------------------
INSERT INTO `trainparter` VALUES ('1', '00ab4c4c-6a29-4b46-9db4-fd95ab54f09a', '46f96e23-eadc-469c-a450-109542efc720', '0', '2017-01-16 17:30:00', '1', '2017-01-16 17:30:00', null, null, null, null, null);

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `ID` varchar(64) NOT NULL,
  `AccountTypeID` varchar(64) DEFAULT NULL COMMENT '账号类型ID',
  `RoleID` varchar(64) DEFAULT NULL COMMENT '角色编号',
  `UserName` varchar(64) DEFAULT NULL COMMENT '用户名',
  `Passsword` varchar(128) DEFAULT NULL COMMENT '密码',
  `SecretKey` varchar(64) DEFAULT NULL COMMENT '秘钥',
  `Gender` varchar(64) DEFAULT NULL COMMENT '性别 0 男1 女',
  `NickName` varchar(128) DEFAULT NULL COMMENT '昵称',
  `LogoID` varchar(64) DEFAULT NULL COMMENT '头像ID',
  `EMail` varchar(128) DEFAULT NULL COMMENT '邮箱',
  `IsBindEmail` tinyint(1) DEFAULT NULL COMMENT '是否绑定邮箱（true已经绑定false未绑定）',
  `BindEmailTime` datetime DEFAULT NULL COMMENT '绑定Email时间',
  `TrueName` varchar(64) DEFAULT NULL COMMENT '真实姓名',
  `Phone` varchar(16) DEFAULT NULL COMMENT '联系电话',
  `IsBindPhone` tinyint(1) DEFAULT NULL COMMENT '是否绑定手机号码（true已经绑定false未绑定）',
  `AgreeCode` varchar(64) DEFAULT NULL COMMENT '审批状态（1通过2未通过 0未审批）',
  `AgreeTime` datetime DEFAULT NULL COMMENT '审批时间',
  `AgreeUserID` varchar(64) DEFAULT NULL COMMENT '审批人',
  `IsOrg` tinyint(1) DEFAULT NULL COMMENT '是否为机构true机构',
  `OrgID` varchar(64) DEFAULT NULL COMMENT '机构ID',
  `IsEnable` tinyint(1) DEFAULT NULL COMMENT '是否启用（true 启用 false 停用）',
  `WetChat` varchar(128) DEFAULT NULL COMMENT '微信',
  `BirthDay` datetime DEFAULT NULL COMMENT '生日',
  `IsLogin` tinyint(1) DEFAULT NULL COMMENT '是否允许登录(true允许fals 不允许)',
  `StudentID` varchar(64) DEFAULT NULL,
  `ReMark` varchar(256) DEFAULT NULL COMMENT '备注',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间（注册时间）',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('033b83fd-97de-4e38-bcad-422b1132c76e', null, '0b395a53-d93d-426c-a29d-61b7bd8dd19c', '1008', '1dde0a5ca2cf3198908beb6f5ceaa8ff', '8c5af81bef17d00a', '0', null, null, null, null, null, 'xingmin', null, null, '1', '2017-02-08 10:04:20', null, null, '88c9ce67-7ad2-4136-b8d4-6bcd4707907c', '1', null, null, '1', null, null, null, '2017-02-08 10:04:20', null, null, null, null, null);
INSERT INTO `user` VALUES ('10ae33ca-a714-4a04-bd0e-7d468e61dfe0', null, '8eabdc8f-7e20-47f4-8acf-1c4678d53559', 'stu001', 'bfbd433f50ee18acd0ca39efd579166d', 'bb5ae66b67cef842', '0', null, null, null, null, null, '张三', null, null, '1', '2017-05-31 15:57:39', '8abacd53-f43b-4d28-b8da-ebc82a5df624', null, '5409875a-43bf-4767-9f14-cec777fcdce4', '1', null, null, '1', null, null, null, '2017-04-19 09:48:35', null, null, null, null, null);
INSERT INTO `user` VALUES ('24aaad2a-dee0-4fec-89d5-5d357f011470', null, '45f91ddc-0f21-4dc4-a439-3447664d859b', '123', '19f740f8623e27ffc46dd803f1dc864a', 'a96c0f6b97eecb05', '0', null, null, null, null, null, '55', '6666', null, '1', '2017-05-31 15:33:57', null, null, '5409875a-43bf-4767-9f14-cec777fcdce4', null, null, null, '1', null, null, null, '2017-05-31 15:33:57', null, null, '1', null, null);
INSERT INTO `user` VALUES ('2b4ba887-b9d9-4a44-a981-c316da2566f7', null, '0b395a53-d93d-426c-a29d-61b7bd8dd19c', '35', '6b84635534aa50a6824895c8908cfcf6', 'a855603f6fde4ce9', '0', null, null, '3', null, null, '33', '3', null, '1', '2017-06-01 16:31:05', null, null, '88c9ce67-7ad2-4136-b8d4-6bcd4707907c', '1', '3', '2017-06-06 00:00:00', '0', null, null, null, '2017-06-01 16:31:05', null, '2017-06-01 16:33:05', '1', null, null);
INSERT INTO `user` VALUES ('38366d6b-244a-4d9a-95fa-71b93a350c6f', null, '5d6f5486-9542-4789-ac16-e06fbb39e9ed', 'xxxx', '70d4b4d5deb9099a0f522733e7f54ed5', 'c0b1d3041c30fda8', '0', null, null, null, null, null, 'xxx', '133333333', null, '1', '2017-06-01 15:28:15', '8abacd53-f43b-4d28-b8da-ebc82a5df624', null, '5409875a-43bf-4767-9f14-cec777fcdce4', null, null, null, '1', null, null, null, '2017-03-10 16:19:09', null, '2017-05-31 15:57:01', null, null, null);
INSERT INTO `user` VALUES ('46f96e23-eadc-469c-a450-109542efc720', null, 'e36b756a-dcce-4aa8-b00a-e8e31db6641a', '1003', 'e2af99e908da20e743f78f1c18a51aca', '406634f92d9f56f2', '0', null, null, null, null, null, '哈哈哈', '11111', null, '1', '2017-01-15 17:19:55', null, null, 'ab87c79c-0773-4ff4-9b0e-621f9a4f120e', '1', null, null, '1', null, '123', null, '2017-01-15 17:19:55', null, '2017-03-10 11:52:50', null, null, null);
INSERT INTO `user` VALUES ('4ad66d57-3184-4cd7-a4f2-faa425ffe667', null, '6046a949-89d5-47ad-a965-79b44a45996e', '1001', 'f46d7a70cc769fcbc848c9f9428edee0', '071fd92f4de6ccc2', '0', null, null, null, null, null, '1001', '13009908080', null, '1', '2017-03-06 17:38:19', '8abacd53-f43b-4d28-b8da-ebc82a5df624', null, '5409875a-43bf-4767-9f14-cec777fcdce4', '1', null, null, '1', null, '3213213', null, '2017-01-15 14:28:38', null, '2017-03-03 09:59:39', null, null, null);
INSERT INTO `user` VALUES ('509e10c3-a42b-4f6a-ac51-68dc69d0d5a3', null, '45f91ddc-0f21-4dc4-a439-3447664d859b', 'me', '53d23636e09a73ee5b35c9c0075588e8', 'e24b53687ef1e944', '0', null, null, null, null, null, '11', '11', null, '1', '2017-05-31 15:24:12', null, null, '5409875a-43bf-4767-9f14-cec777fcdce4', null, '11', null, '1', null, null, null, '2017-05-31 15:24:12', null, null, '1', null, null);
INSERT INTO `user` VALUES ('5bedd188-1d17-44fa-8308-29b3c46aa23e', null, '628e2960-707e-4574-878c-c50ad45a3ec8', 'Tea001', '31b999d45cc1523c2ed13f0d7819b8f2', '29860e2727687dc8', '0', null, null, null, null, null, '老师张', null, null, '1', '2017-04-19 09:51:06', null, null, '5409875a-43bf-4767-9f14-cec777fcdce4', null, null, null, '1', null, null, null, '2017-04-19 09:51:06', null, null, null, null, null);
INSERT INTO `user` VALUES ('64d5b810-595d-40fc-bc92-04425166430d', null, '5d6f5486-9542-4789-ac16-e06fbb39e9ed', '1002', 'fbb09fd01730cf318db3cd682265ec73', 'e688b52f095951e4', '0', null, null, null, null, null, '123', '144', null, '2', '2017-06-01 15:28:39', '8abacd53-f43b-4d28-b8da-ebc82a5df624', null, '5409875a-43bf-4767-9f14-cec777fcdce4', '1', null, null, '0', '20150001', null, null, '2017-01-15 15:03:38', null, '2017-03-10 16:17:27', null, null, null);
INSERT INTO `user` VALUES ('689af79b-63b0-417f-9275-401a71da0870', null, '0b395a53-d93d-426c-a29d-61b7bd8dd19c', '122', 'eeb1148b5f297a2311f2071215b645f3', '526f7e35770dcd78', '0', null, null, '21', null, null, '12', '21', null, '1', '2017-06-01 16:51:13', null, null, '88c9ce67-7ad2-4136-b8d4-6bcd4707907c', '1', '21', '2017-05-09 00:00:00', '1', null, '12', null, '2017-06-01 16:51:13', null, null, null, null, null);
INSERT INTO `user` VALUES ('8abacd53-f43b-4d28-b8da-ebc82a5df624', null, '45f91ddc-0f21-4dc4-a439-3447664d859b', 'admin', '7b41c073c904a31344f6978a340153eb', 'd0998b119685f6a1', '1', '管理员', '', null, null, null, 'admin', null, null, '1', '2017-03-03 10:18:15', null, null, 'ab87c79c-0773-4ff4-9b0e-621f9a4f120e', '1', null, '2017-01-01 00:00:00', '1', null, null, null, '2017-03-03 10:18:15', null, '2017-06-01 14:39:22', null, null, null);
INSERT INTO `user` VALUES ('cf431597-5ca0-47a0-adbc-f69136dfdcb1', null, '45f91ddc-0f21-4dc4-a439-3447664d859b', '157', '7afcfabb6bf488a45eec355d3d0753e5', '71ee13af7d90ce0b', '0', null, null, '12', null, null, '123', '12', null, '1', '2017-06-01 14:24:46', null, null, '8a745b2c-0cab-48b5-a55c-485b21a0b8aa', '1', '12', '2017-06-07 00:00:00', '1', null, '21', null, '2017-06-01 14:24:46', null, '2017-06-01 14:26:11', '1', null, null);

-- ----------------------------
-- Table structure for `usercollect`
-- ----------------------------
DROP TABLE IF EXISTS `usercollect`;
CREATE TABLE `usercollect` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户编号ID',
  `EmployID` varchar(64) DEFAULT NULL COMMENT '招聘岗位ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户收藏';

-- ----------------------------
-- Records of usercollect
-- ----------------------------

-- ----------------------------
-- Table structure for `userdata`
-- ----------------------------
DROP TABLE IF EXISTS `userdata`;
CREATE TABLE `userdata` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `FileID` varchar(64) DEFAULT NULL COMMENT '文件ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户材料表';

-- ----------------------------
-- Records of userdata
-- ----------------------------
INSERT INTO `userdata` VALUES ('64d5b810-595d-40fc-bc92-04425166430f', '64d5b810-595d-40fc-bc92-04425166430d', '6-6-6', '64d5b810-595d-40fc-bc92-04425166430d', '2016-08-08 18:08:08', null, null, null, null, null);

-- ----------------------------
-- Table structure for `userrole`
-- ----------------------------
DROP TABLE IF EXISTS `userrole`;
CREATE TABLE `userrole` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `RoleID` varchar(64) DEFAULT NULL COMMENT '角色ID',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户角色表';

-- ----------------------------
-- Records of userrole
-- ----------------------------

-- ----------------------------
-- Table structure for `workexperience`
-- ----------------------------
DROP TABLE IF EXISTS `workexperience`;
CREATE TABLE `workexperience` (
  `ID` varchar(64) NOT NULL,
  `UserID` varchar(64) DEFAULT NULL COMMENT '用户ID',
  `CompanyName` varchar(128) DEFAULT NULL COMMENT '公司名',
  `Position` varchar(64) DEFAULT NULL COMMENT '职位',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `WorkContent` varchar(512) DEFAULT NULL COMMENT '工作内容',
  `CreatorUserId` varchar(64) DEFAULT NULL COMMENT '创建用户',
  `CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `LastModifyUserId` varchar(64) DEFAULT NULL COMMENT '最后修改用户',
  `LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `DeleteMark` tinyint(1) DEFAULT NULL COMMENT '删除标志',
  `DeleteUserId` varchar(64) DEFAULT NULL COMMENT '删除用户',
  `DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='工作经验';

-- ----------------------------
-- Records of workexperience
-- ----------------------------
