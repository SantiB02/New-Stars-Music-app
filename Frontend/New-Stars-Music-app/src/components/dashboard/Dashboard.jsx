import {
  Typography,
  Button,
  Tabs,
  TabsHeader,
  Tab,
  TabsBody,
  TabPanel,
} from "@material-tailwind/react";
import React, { useState, useEffect } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import UsersReport from "./UsersReport";
import ProductsReport from "./ProductsReport";
import SaleOrdersReport from "./SaleOrdersReport";
import MessageReport from "./MessageReport";

const Dashboard = () => {
  const { theme } = useTheme();

  return (
    <div className="max-w-7xl mx-8 py-6">
      <Typography variant="h2" className="font-light">
        Dashboard
      </Typography>
      <Tabs value="users">
        <TabsHeader className="bg-transparent">
          <Tab
            value="users"
            className="mx-2 md:mx-10 rounded-full bg-orange-500"
          >
            Users
          </Tab>
          <Tab
            value="products"
            className="mx-2 md:mx-10 rounded-full bg-orange-500"
          >
            Products
          </Tab>
          <Tab
            value="sale orders"
            className="mx-2 md:mx-10 rounded-full bg-orange-500"
          >
            Sale Orders
          </Tab>
          <Tab
            value="messages"
            className="mx-2 md:mx-10 rounded-full bg-orange-500"
          >
Messages          </Tab>
        </TabsHeader>
        <TabsBody>
          <TabPanel value="users">
            <UsersReport theme={theme} />
          </TabPanel>
          <TabPanel value="products">
            <ProductsReport theme={theme} />
          </TabPanel>
          <TabPanel value="sale orders">
            <SaleOrdersReport theme={theme} />
          </TabPanel>
          <TabPanel value="messages">
            <MessageReport theme={theme} />
          </TabPanel>
        </TabsBody>
      </Tabs>
    </div>
  );
};

export default Dashboard;
