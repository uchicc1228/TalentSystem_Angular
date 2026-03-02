export interface TalentInfo {
  talentID: string;          // nvarchar(50), PK
  talentName: string;        // nvarchar(100), NOT NULL
  email?: string;            // nvarchar(100), 可為 NULL
  sex: boolean;              // bit, NOT NULL
  phone?: string;            // nvarchar(20), 可為 NULL
  mobilePhone?: string;      // nvarchar(20), 可為 NULL
  workAreas?: string;        // nvarchar(max), 可為 NULL
  skills?: string;           // nvarchar(max), 可為 NULL
  status: boolean;           // bit, NOT NULL
  creationTime: Date;        // datetime2(7), NOT NULL
  lastModifiedAt?: Date;     // datetime2(7), 可為 NULL
  lastModifiedBy?: string;   // nvarchar(50), 可為 NULL
}
