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
      <div className="overflow-x-auto justify-center mt-6">
        <Tabs value="users" className="whitespace-nowrap">
          <TabsHeader className="bg-transparent flex">
            <Tab
              value="users"
              className="flex-1 mx-2 md:mx-4 lg:mx-6 xl:mx-8 my-2 md:my-0 rounded-full bg-orange-500 text-center py-2 md:py-3 cursor-pointer text-sm md:text-base"
            >
              Users
            </Tab>
            <Tab
              value="products"
              className="flex-1 mx-2 md:mx-4 lg:mx-6 xl:mx-8 my-2 md:my-0 rounded-full bg-orange-500 text-center py-2 md:py-3 cursor-pointer text-sm md:text-base"
            >
              Products
            </Tab>
            <Tab
              value="sale orders"
              className="flex-1 mx-2 md:mx-4 lg:mx-6 xl:mx-8 my-2 md:my-0 rounded-full bg-orange-500 text-center py-2 md:py-3 cursor-pointer text-sm md:text-base"
            >
              Sale Orders
            </Tab>
            <Tab
              value="messages"
              className="flex-1 mx-2 md:mx-4 lg:mx-6 xl:mx-8 my-2 md:my-0 rounded-full bg-orange-500 text-center py-2 md:py-3 cursor-pointer text-sm md:text-base"
            >
              Messages
            </Tab>
          </TabsHeader>
          <TabsBody className="mt-4 overflow-x-auto">
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
    </div>
  );
};

export default Dashboard;
