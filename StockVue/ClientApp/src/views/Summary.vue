<template>
    <v-container fluid>
        <v-layout column align-center>
            <h1>Portfolio Summary</h1>
            <BalanceSnapshot />
            <PortfolioSummary />
            <BalanceHistory />
        </v-layout>
    </v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import PortfolioSummary from '@/components/PortfolioSummary.vue'; // @ is an alias to /src
    import BalanceSnapshot from '@/components/BalanceSnapshot.vue';
    import BalanceHistory from '@/components/BalanceHistory.vue';

    @Component({
        components: {
            PortfolioSummary,
            BalanceSnapshot,
            BalanceHistory,
        },
    })
    export default class Summary extends Vue {
        async mounted() {
            console.log("mounted");
            if (isNaN(this.$store.state.summary.balance)) {
                this.fetchData()
            }
            if (this.$store.state.history.data.length == 0) {
                this.fetchHistoryData()
            }
        }

        public fetchData(): void {
            this.$store.dispatch("loadSummaryData");
        }

        public fetchHistoryData(): void {
            this.$store.dispatch("loadHistoryData");
        }
    }
    
</script>
