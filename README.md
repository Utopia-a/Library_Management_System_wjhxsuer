## 图书管理系统开发日志

---

这是一个用C#语言，基于Winform控件的图书管理系统


目前实现的功能阐述：

数据库（BooKDB）表：

```
t_user
属性：id，password, name, sex, money

t_admin
属性：id, password

t_book
属性：id，name， author, press,stock

t_borrow
属性：no， uid， bid，date， rdate，fine
```



用户端：

```
借书 -- 余额判断，借书书本限制，库存判断，已借判断
还书 -- 还书结算金额，借书扣款0.1元，超过30天，每天计0.1元
充值
查看读者卡 -- 读者姓名，性别，用户号，余额，总共借书本书
修改密码 -- 修改密码，自动跳转登录界面功能
查看已借书本
联系管理员
注册信息
```

管理员端

```
查看借阅情况
查询读者借阅情况
添加书本
删除书本
查询书本
修改书本
注册信息
```

若是有需要学习的朋友，请务必在克隆项目到本地的基础上，安装SunnyUI 和 CSkin两个控件，安装地址如下：
https://gitee.com/yhuse/SunnyUI（sunnyUI）  

http://www.cskin.net/（CSkin）

