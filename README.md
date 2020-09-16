# Promotion-Engine

Below tables are considered in this project to make it configurable.  
	
- Item Master
- Promotions Rule Type
- Active Promotions Rule

Note - Hard-coded data is returned due to unavailability of SQL server

# Description for tables
 1. ItemMaster - Master data for items. i.e. A,B,C,D...
 2. PromotionsRuleType - List of Promotion Rule type. i.e. Combo offer, On plus one offer
 3. ActivePromotionRule - List of current promotion rules for items. It's configurable. We can change the paramaterised logic anytime for existing rule. i.e. qty,price. Also we can set up existing promotion rule for items.
 
 We need to change code only for new rule type. 
